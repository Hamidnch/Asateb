// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function() {
    $(".btn-select").on("click", function (e) {
            var self = $(this);
        $(this).closest("select.tech-select").css({ "color": "red", "background-color": "black" });
            var x = self.closest(".tech-select option:selected").text();
       
        self.closest(".card").css({ "background-color": "silver", "border": "2px solid red" });

    });

    $("select.tech-select").change(function() {
        var self = $(this);
/*        self.closest("select").css({ "color": "red", "background-color": "black" });*/
        var card = self.closest(".card");
        card.css({ "background-color": "silver", "border": "2px solid red" });
        card.closest(".btn-select").css({ "background-color": "black", "border": "2px solid red" });
    });
});




function save(){
    e.preventDefault();
    var listContents = [];
    $("ul").each(function () {
        listContents.push(this.innerHTML);
    })
    localStorage.setItem('todoList', JSON.stringify(listContents));
};

function clearAll() {
    e.preventDefault();
    localStorage.clear();
    location.reload();
};

function load() {
    if (localStorage.getItem('todoList')) {
        var listContents = JSON.parse(localStorage.getItem('todoList'));
        $("ul").each(function (i) {
            this.innerHTML = listContents[i];
        })
    }
}