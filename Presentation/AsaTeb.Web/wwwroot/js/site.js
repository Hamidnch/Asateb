if (document.readyState == "loading") {
    document.addEventListener("DOMContentLoaded", ready);
} else {
    ready();
}

function ready() {
    var addButtons = document.getElementsByClassName("btn-select");
    for (var i = 0; i < addButtons.length; i++) {
        var addButton = addButtons[i];
        addButton.addEventListener('click', addButton_Clicked);
    }
    var choiceLink = document.getElementsByClassName("choice-link")[0];
    choiceLink.addEventListener("mouseover",
        function() {
            $(".my-choice").css("display", "block");
        });
    choiceLink.addEventListener("mouseleave",
        function () {
            $(".my-choice").css("display", "none");
        });
}

function addButton_Clicked(event) {
    var button = event.target;
    var card = button.parentElement.parentElement;
    card.style.color = "crimson";
    card.style.backgroundColor = "lemonchiffon";
    card.style.borderColor = "red";

    var fullName = card.getElementsByClassName("card-header")[0].innerText;
    var email = card.getElementsByClassName("card-title")[0].innerText;
    var img = card.getElementsByClassName("image-custom")[0].src;

    addCandidateToChoice(fullName, email, img);
    //card.remove();
}

function addCandidateToChoice(fullName, email, img) {
    var newCandidate = document.createElement("table");
    newCandidate.setAttribute("border", "1");
    var tr = document.createElement('tr');
    var tdFullName = document.createElement('td');
    var tdEmail = document.createElement('td');
    var tdImg = document.createElement('td');

    tdFullName.setAttribute("border", "solid");
    tdEmail.setAttribute("border", "solid");
    tdImg.setAttribute("border", "solid");

    var fullNameText = document.createTextNode(fullName);
    var emailText = document.createTextNode(email);


    var imgTag = document.createElement("img");
    imgTag.style.width = "70px";
    imgTag.style.height = "70px";
    imgTag.src = img;
    tdImg.appendChild(imgTag);

    tdFullName.appendChild(fullNameText);
    tdEmail.appendChild(emailText);

    tr.appendChild(tdImg);
    tr.appendChild(tdFullName);
    tr.appendChild(tdEmail);

    newCandidate.appendChild(tr);

    var myChoice = document.getElementsByClassName("my-choice")[0];
    myChoice.append(newCandidate);
}

//$(function () {
//    $(".btn-select").on("click", function (e) {
//            var self = $(this);
//        $(this).closest("select.tech-select").css({ "color": "red", "background-color": "black" });
//            var x = self.closest(".tech-select option:selected").text();
       
//        self.closest(".card").css({ "background-color": "silver", "border": "2px solid red" });

//    });

//    $("select.tech-select").change(function() {
//        var self = $(this);
//*        self.closest("select").css({ "color": "red", "background-color": "black" });*/
//        var card = self.closest(".card");
//        card.css({ "background-color": "silver", "border": "2px solid red" });
//        card.closest(".btn-select").css({ "background-color": "black", "border": "2px solid red" });
//    });
//});


//function save(){
//    e.preventDefault();
//    var listContents = [];
//    $("ul").each(function () {
//        listContents.push(this.innerHTML);
//    })
//    localStorage.setItem('todoList', JSON.stringify(listContents));
//};

//function clearAll() {
//    e.preventDefault();
//    localStorage.clear();
//    location.reload();
//};

//function load() {
//    if (localStorage.getItem('todoList')) {
//        var listContents = JSON.parse(localStorage.getItem('todoList'));
//        $("ul").each(function (i) {
//            this.innerHTML = listContents[i];
//        })
//    }
//}