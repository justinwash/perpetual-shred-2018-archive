var player;

function onYouTubePlayerAPIReady() {
    player = new YT.Player('video', {
        events: { 'onReady': onPlayerReady }
    });
}

function onPlayerReady(event) {

    var playButton = document.getElementById("play-button");
    playButton.addEventListener("click", function () {
        if (player.getPlayerState() == 1) {
            playButton.innerHTML = "Play";
            player.pauseVideo();

        } else {
            playButton.innerHTML = "Pause";
            player.playVideo();

        }

    });

    var muteButton = document.getElementById("mute-button");
    muteButton.addEventListener("click", function () {
        if (player.isMuted()) {
            player.unMute();
            muteButton.innerHTML = "Mute";
        } else {
            player.mute();
            muteButton.innerHTML = "Unmute";
        }
    });

    var moreButton = document.getElementById("more");
    moreButton.addEventListener("click", function () {
        console.log("more clicked");
        playButton.innerHTML = "Play";
        player.pauseVideo();
    })
}
