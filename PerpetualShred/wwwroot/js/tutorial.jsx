var CommentBox = React.createClass({
    render: function () {
        return (
            <div className="commentBox">
                Testing React.js integration!
      </div>
        );
    }
});
ReactDOM.render(
    <CommentBox />,
    document.getElementById('content')
);
