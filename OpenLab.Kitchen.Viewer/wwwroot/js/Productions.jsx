var ProductionList = React.createClass({
    getInitialState: function() {
        return { data:[] }
    },
    componentWillMount: function() {
        var xhr = new XMLHttpRequest();
        xhr.open('get', this.props.url, true);
        xhr.onload = function () {
            var data = JSON.parse(xhr.responseText);
            this.setState({ data: data });
        }.bind(this);
        xhr.send();
    },
    render: function() {
        var productionNodes = this.state.data.map(function(production) {
            return (
                <Production key={production.id} data={production} />
            );
        });
        return (
            <table className="table table-striped">
                <thead>
                <tr>
                    <th>Name</th>
                </tr>
                </thead>
                <tbody>
                    {productionNodes}
                </tbody>
            </table>
        );
    }
});

var Production = React.createClass({
    render: function () {
        return (
            <tr>
                <td>{this.props.data.name}</td>
            </tr>
        );
    }
});

ReactDOM.render(
    <ProductionList url="http://localhost:54532/api/production" />,
    document.getElementById('productions')
);