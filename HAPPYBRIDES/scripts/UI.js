function toggleUI(isLoggedIn, isGuest) {
    toggleNavbarLogin(isLoggedIn);
    toggleInfoLabel(isLoggedIn, isGuest);
    toggleListAddButton(isLoggedIn);
    togglePageView(isGuest, isLoggedIn);
}
function toggleNavbarLogin(isUserLoggedIn) {
    if (isUserLoggedIn) {
        $("#navbarLogin").addClass('hidden');
        $("#navbarLogout").removeClass('hidden');
    } else {
        $("#navbarLogin").removeClass('hidden');
        $("#navbarLogout").addClass('hidden');
    }
}
function togglePageView(isGuest, isLoggedIn) {
    (isGuest || isLoggedIn) ? navigate("./list/list.html") : navigate("./home/home.html");
}

function toggleListAddButton(isLoggedIn) {

    if (isLoggedIn) {
        $("#btnListAdd").css('display', 'block');
    } else {
        $("span.header").css('justify-content', 'center');
    }
}
function toggleInfoLabel(isLoggedIn, isGuest) {
    var infoLables = new Object();
    infoLables.guestInfo = "This wish list was created by Alice and Bob, they put the items they want the most at the top of the list.\
   Click an item to select it as your chosen gift, a window will appear where you can mention any contributors.\
   The couple can't see what you selected, other guests won't be able to see your chosen item on this list when you confirm your choice.";

    infoLables.coupleInfo = "This is your wish list, click an item to edit or delete it, or change it's order. You can log in any time and\
   change your list. This is the same list your guests will see.";

    infoLables.homeInfo = "Register or log in if you're a couple to work on your wish list. Enter the unique code your couple has received\
   when registering, so you can view the wish list.";

    if (isLoggedIn || isGuest) {
        if (isLoggedIn) {$("#infoIcon").tooltip({ title: infoLables.coupleInfo });}
        if (isGuest) {$("#infoIcon").tooltip({ title: infoLables.guestInfo });}
    } else {
        $("#infoIcon").tooltip({ title: infoLables.homeInfo });
    }
}