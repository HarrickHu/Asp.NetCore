let connection = null;

(setupConnaction = () => {
    connection = new signalR.HubConnectionBuilder().withUrl("/counthub").build();

    connection.on("ReceiveUpdate", (update) => {
        const lblResult = document.getElementById("lblResult");
        lblResult.innerHTML = update;
    });

    connection.on("someFunc", function(obj) {
        const lblResult = document.getElementById("lblResult");
        lblResult.innerHTML = "Someone called, parameters: " + obj.random;
    });

    connection.on("Finished", function() {
        connection.stop;
        const lblResult = document.getElementById("lblResult");
        lblResult.innerHTML = "Finished";
    });

    connection.start().catch(err=> console.error(err.toString()));
})();

document.getElementById("btnSubmit").addEventListener("click", e => {
    e.preventDefault();

    fetch("/api/count",
        {
            method: "POST",
            headers: {
                'content-type': 'application/json'
            }
        })
        .then(response => response.text())
        .then(id => connection.invoke("GetLatestCount", id));
});

