window.onload = function () {
  //  pb = window.pb || {};



    var pbTrackPlugin = function (player, options) {
        var played = 0;

        var trackVideoStart = function () {
            player.off('play', trackVideoStart); //remove listener after first time

            // blockers may do all sort of weird stuff to gaq
            window.ga = window.ga || function () { (ga.q = ga.q || []).push(arguments) }; ga.l = +new Date;
            try {
                ga('send', 'event', 'videoplayer', 'start', player.pbvideoid);
            } catch (er) { }

            var parentpb = "0";
            var parenturl = "";
            var embed = "";
            var ref = 1;
            var op = played > 0 ? 'rewatch' : 'gvtest';
            try {
                pb.rmsSend({
                    "mod": "video",
                    "op": op,
                    "ref": player.pbref,
                    "id": player.pbvideoid,
                    "uid": player.pbuserid,
                    "player": "html5",
                    embed: embed,
                    parentpb: parentpb,
                    parenturl: parenturl,
                });
            } catch (err) { }

            played++;
        }

        player.on('play', trackVideoStart);

        player.on('ended', function (ev) {
            player.on('play', trackVideoStart); // listen for another start if we get to end

            // blockers may do all sort of weird stuff to gaq
            window.ga = window.ga || function () { (ga.q = ga.q || []).push(arguments) }; ga.l = +new Date;
            try {
                ga('send', 'event', 'videoplayer', 'end', player.pbvideoid);
            } catch (er) { }

        });
    };
    var pbTrack = function (options) {
        this.ready(function () {
            pbTrackPlugin(this, options);
        });
    };
    videojs.plugin('pbTrack', pbTrack);



    var pbairplayPlugin = function (player, options) {
        if (options.pbairplay) {

            var videoEl = player.el().getElementsByTagName('video')[0];

            if (window.WebKitPlaybackTargetAvailabilityEvent) {

                var containerElement = document.createElement("div");
                containerElement.className = "vjs-pbairplay vjs-control vjs-button";
                containerElement.style.display = 'none';

                containerElement.addEventListener('click', function () {
                    videoEl.webkitShowPlaybackTargetPicker();
                }, false);

                player.controlBar.el().appendChild(containerElement);

                videoEl.addEventListener('webkitplaybacktargetavailabilitychanged', function (event) {
                    switch (event.availability) {
                        case "available":
                            containerElement.style.display = 'block';
                            break;
                        default:
                            containerElement.style.display = 'none';
                    }
                });
            }

        }
    };

    var pbairplay = function (options) {
        this.ready(function () {
            pbairplayPlugin(this, options);
        });
    };
    videojs.plugin('pbairplay', pbairplay);



    var pblogoPlugin = function (player, options) {
        if (options.pblogo) {
            var containerElement = document.createElement("div");
            containerElement.className = "vjs-pblogo vjs-control vjs-button";
            var linkElement = document.createElement("a");
            linkElement.setAttribute("href", options.destination);
            linkElement.setAttribute("title", options.title);
            linkElement.setAttribute("target", options.destinationTarget);
            containerElement.appendChild(linkElement);
            player.controlBar.el().appendChild(containerElement);
        }
    };

    var pblogo = function (options) {
        this.ready(function () {
            pblogoPlugin(this, options);
        });
    };
    videojs.plugin('pblogo', pblogo);



    var pbrelatedPlugin = function (player, options) {
        var related = document.createElement("div");
        related.className = "vjsrelated";
        player.el().appendChild(related);

        player.on('ended', function () {
            pb.rmsSend({ mod: 'video', tar: 'video', op: 'getrelated', iUserId: this.pbuserid }, function (oRmsR) {
                if (oRmsR.rmsS) {
                    if (oRmsR.rmsD.length > 0) {
                        var url = "https://www.pinkbike.com/video/";
                        var imageurl = "https://ev1.pinkbike.org/vt/svt-";
                        var html = "";
                        for (var i = 0; i < oRmsR.rmsD.length; i++) {
                            var url = "https://www.pinkbike.com/video/";
                            var imageurl = "https://ev1.pinkbike.org/vt/svt-";
                            html += "<div class=\"vjsthumbnailcontainer\">";
                            html += "<div class=\"vjsthumbnailitem\" style=\"background-image: url('" + imageurl + oRmsR.rmsD[i]['id'] + "-2.jpg');\">";
                            html += "<a href=\"" + url + oRmsR.rmsD[i]['id'] + "/\" target=\"_top\"><span class=\"vjsbottomtextcontainer\"><span class=\"vjsbottomtext\"><b>" + oRmsR.rmsD[i]['title'] + "</b><br />" + oRmsR.rmsD[i]['views'] + " views</span></span></a>";
                            html += "</div>";
                            html += "</div>";
                        }
                        $(related).html(html);
                        $(related).fadeIn();
                    }
                }
            });
        });

        player.on('play', function () {
            $(related).hide();
        });
    };

    var pbrelated = function (options) {
        this.ready(function () {
            pbrelatedPlugin(this, options);
        });
    };
    videojs.plugin('pbrelated', pbrelated);


    function adOverlayClick(element) {
        var player = videojs($(element).parent().find("video")[0]);
        player.play();
        $(element).remove();
    }

    function initializeVideoJS(element, volume) {
        //don't initialize more than once
        if ($(element).data("video-initialized")) {
            return;
        }
        $(element).data("video-initialized", true);

        var autoplay = false;
        if (typeof ($(element).attr("data-autoplay")) != "undefined") {
            autoplay = ($(element).attr("data-autoplay").toLowerCase() === "true");
        }
        var initialquality = "480";
        if (typeof ($(element).attr("data-initialquality")) != "undefined") {
            initialquality = $(element).attr("data-initialquality");
        }

        var pblogo = false;
        if (typeof ($(element).attr("data-pblogo")) != "undefined") {
            pblogo = ($(element).attr("data-pblogo").toLowerCase() === "true");
        }

        var id = $(element).attr("id");

        var adtag = $(element).attr('data-adtag');

        var overlay = $(element).parent().find(".vjsoverlay");
        if (adtag) {
            var adoverlay = $(element).parent().find(".vjsadoverlay");
        }

        var player = videojs(element, {
            controlBar: {
                children: [
                    'playToggle',
                    {
                        name: 'progressControl',
                        children: [
                            'currentTimeDisplay',
                            'SeekBar',
                            'durationDisplay'
                        ]
                    },
                    'volumeMenuButton',
                    'resolutionMenuButton',
                    'fullscreenToggle'
                ],
                volumeMenuButton: {
                    inline: false,
                    vertical: true
                }
            }, autoplay: autoplay, controls: true,

            plugins: {
                videoJsResolutionSwitcher: {
                    default: initialquality,
                    dynamicLabel: true
                },
                pblogo: {
                    pblogo: pblogo,
                    title: "Watch on Pinkbike",
                    destination: "https://www.pinkbike.com/video/" + $(element).attr("data-videoid") + "/",
                    destinationTarget: "_top"
                },
                pbairplay: {
                    pbairplay: pbairplay,
                    title: "Watch on Pinkbike",
                    destination: "https://www.pinkbike.com/video/" + $(element).attr("data-videoid") + "/",
                    destinationTarget: "_top"
                },
                pbrelated: {
                },
                pbTrack: {
                }
            },

        }, function () {
            this.on('resolutionchange', function () {
                pb.setCookie("pbvq", this.currentResolution().label, 14);
            });
            this.on('volumechange', function () {
                pb.setCookie("pbvol", this.volume(), 14);
            });

            // Headshot/title overlay
            var hideOverlay = function () {
                if (this.currentTime() > 5) {
                    overlay.fadeOut();
                    this.off('timeupdate', hideOverlay);
                }
            }
            this.on('timeupdate', hideOverlay);

            this.pbvideoid = $(element).attr("data-videoid");
            this.pbuserid = $(element).attr("data-userid");
            this.pbref = $(element).attr("data-ref");


            if (adtag && typeof this.ads != 'undefined') {
                try {
                    var options = {
                        id: id
                    };

                    this.ima(options);

                    this.one('play', function () {
                        adoverlay.remove();
                        overlay.css("z-index", "auto");
                        $(element).parent().find(".vjs-control-bar").hide();
                        this.ima.initializeAdDisplayContainer();
                        this.ima.setContentWithAdTag(null, adtag, true);
                        this.ima.requestAds();
                        this.play();
                    });

                    ['adend', 'adskip', 'adserror', 'contentstarted'].forEach(function (e) {
                        player.on(e, function () {
                            overlay.css("z-index", "999");
                            $(element).parent().find(".vjs-control-bar").show();
                        });
                    });
                } catch (err) {
                    console.log('video error: ' + err);
                }
            }

            this.on('error', function () {
                if (this.error().code === 4) {
                    if (this.currentResolution()['label'] != "480p") {
                        this.error(null);
                        this.currentResolution('480p');
                        this.play();
                        return;
                    }
                }
                overlay.fadeOut();
                this.off('timeupdate', hideOverlay);
            });
        }).ready(function () {
            this.volume(volume);
        });
    }

    function initializeAllVideoJS() {
        var volume = pb.getCookie("pbvol");
        if (volume == null) volume = 1;

        $("video").each(function (index, element) {
            initializeVideoJS(element, volume);
        });
    }

    initializeAllVideoJS();

}