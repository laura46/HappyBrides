function isLoggedIn() {
    return (getCoupleID() == 0 || getCoupleID() == "undefined" || getCoupleID() == null) ? false : true;
}
function isGuest() {
    return (getUniqeCode() == 0 || getUniqeCode() == "undefined" || getUniqeCode() == null) ? false : true;
}
function getUniqeCode(){
    return sessionStorage.getItem("uniqueCode");
}
function getCoupleID() {
    return sessionStorage.getItem("loggedIn");
}
function getListID() {
    return sessionStorage.getItem("listID");
}


function verifyUniqueCode() {
    var code = $("#inputUniqueCode").val().toUpperCase();
    $.ajax({
        type: "GET",
        url: apiUrl + "list/guest/" + code,
        contentType: "application/json;charset=utf-8",
        success: function (data) {
            console.log(data);
            if (data) {
                sessionStorage.setItem("listID",data);
                sessionStorage.setItem("uniqueCode", code);
                toggleUI(false,true);
            } else {
                console.log($("label.warn.hidden"));
                $("label.warn.hidden").removeClass("hidden");
                console.log($("label.warn"));
            }
        }
    });
}
function verifyLogin() {
    var elements = [$("#loginEmail"), $("#loginPassword")];
    if (checkForm(elements)) {
        var request = new Object();
        request.UserName = elements[0].val();
        request.PassWord = elements[1].val();

        $.ajax({
            type: "POST",
            url: apiUrl + "login/login",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(request),
            success: function (data) {
                console.log(data);
                if (data != 0) {
                    closeDialog();
                    login(data);
                    toggleUI(true, false);
                } else {
                    $(".warn").removeClass('hidden');
                    toggleUI(false, false);
                }
            }
        });
    }

    $("#btnLogin").blur();
}
function login(coupleId) {
    sessionStorage.removeItem("listID");
    sessionStorage.removeItem("uniqueCode");
    sessionStorage.setItem("loggedIn", coupleId);
    toggleUI(true, false);
}
function logout() {
    sessionStorage.removeItem("loggedIn");
    sessionStorage.removeItem("listID")
    toggleUI(false, false);
}

function register() {
    var elements = [$('#namePerson1'), $('#namePerson2'), $('#emailAddress'), $('#password')];
    if (checkForm(elements)) {
        var request = new Object();
        request.Name1 = elements[0].val();
        request.Name2 = elements[1].val();
        request.UserName = elements[2].val();
        request.Password = elements[3].val();

        $.ajax({
            type: "POST",
            url: apiUrl + "login/create",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(request),
            success: function (data) {
                openDialog("./elements/dialog/code.dialog.html", data, DIALOG_TYPES.CODE);
            }
        });
    }

    $("#btnRegister").blur();
}
