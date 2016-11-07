var VideoList = React.createClass({
    getInitialState: function () {
        return { media: [] };
    },
    componentWillMount: function () {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ media: data });
        }.bind(this);
        xhr.send();
    },
    render: function () {
        var media = this.state.media.map(function (media) {
            return (
                <option directory={media.folder}>{media.folder}</option>
            );
        });
        return (
            <select className="form-control" onChange={this.handleChange}>
                {media}
            </select>
        );
    },
    handleChange: function(e) {
        
    }
});

var Video = React.createClass({
    handleReadyChange: function(event) {
        
    },
    render: function() {
        return (
            <video data-dashjs-player autoplay controls src={this.props.src}></video>
        );
    }
});