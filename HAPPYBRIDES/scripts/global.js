var apiUrl = "https://localhost:44333/api/";

$(function () {
    $("body").tooltip({ selector: '[data-toggle=tooltip]' });
    toggleUI(isLoggedIn(),isGuest());
   // $(document).on("click", "li span div.list-price", selectItem);
});

function navigate(filePath) {

    $("#pageContent").load(filePath, function () {
        if (filePath == "./list/list.html") {
            console.log(isLoggedIn(),isGuest());

            if(isGuest()){getWishlistForGuest(getListID());}
            if(isLoggedIn()){getWishlistForCouple(getCoupleID());}
        }
    });
}

function checkForm(elements) {
    if(Array.isArray(elements)){
        var isValidForm = true;
        elements.forEach(element => {
            if(element.val() == ""){
                isValidForm = false;
                element.addClass('required');
            } else {
                element.removeClass('required');
            }
        });
        return isValidForm;
    } else {
        var element = $("#"+elements+"")
        if(element.val() == ""){
            element.addClass('required');
        } else {
            element.removeClass('required');
        }
    }
}
