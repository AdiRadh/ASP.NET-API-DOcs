function openMethod(evt, methodName) {
    var i, tabcontent, tablinks;

    tabcontent = document.getElementsByClassName("tabContent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }

    tablinks = document.getElementsByClassName("nav-links");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }

    document.getElementById(methodName).style.display = "block";
    evt.currentTarget.className += " active";

}

function Search(evt, criteria) {
    $.ajax({
        url: '/Search',
        data: { criteria: criteria }
    }).done(function () {
        alert('Added');
    });
}