var viewModel = {
    lookupCollection: ko.observableArray()
};

$(document).ready(funciton(){
    $.ajax({
        type: "GET",
        url: "Lookups/GetIndex"
    }).done(function (data) {
        $(data).each(function (index, element) {
            viewModel.lookupCollection.push(element);
        });
        ko.applyBindings(viewModel);
    }).error(function (ex) {
            alert("Error");
    });
});