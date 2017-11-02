var viewModel = {
    lookupCollection: ko.observableArray()
};

$(document).ready(funciton(){
    $.ajax({
        type: "GET",
        url: "Lookups/GetIndex",
        success: function (data) {
            $(data).each(function (index, element) {
                viewModel.lookupCollection.push(element);
            });
            ko.applyBindings(viewModel);
        },
        error: function () { alert("Error")}
    });
});