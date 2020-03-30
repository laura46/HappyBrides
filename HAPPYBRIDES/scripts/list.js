
function getWishlistForCouple(coupleID){
        $.ajax({
            type: "GET",
            url: apiUrl + "list/couple/" + coupleID,
            contentType: "application/json;charset=utf-8",
            success: function(data){
                sessionStorage.setItem("listID", data.wishListID);
                $("#btnAdd").removeClass('hidden');
                $("span.d").removeClass('hidden');
                $("#name1").text(data.firstName);
                $("#name2").text(data.secondName);

                if(data.wishlistItems != null){
                    generateList(data.wishlistItems,true);
                }
            }
        });

}
function generateList(items, isUser){
    $("ol#wishList").empty();
    items.forEach(item => {
        var htmlString = "<li data-position='"+item.position+"'>";
        if(isUser){
            htmlString += "<div><div onclick='selectItem(this)'>";
        } else {
            htmlString += "<div><div onclick='claimItem(this)'>";
        }
        htmlString += "<span id='description'>" + item.description + "</span>";
        htmlString += "<div class='list-price'><span>€</span><span id='price'>" + item.price + "</span></div></div>";
        if(isUser){
            htmlString += "<div class='list-sort'><label class='fa fa-arrow-up' onclick='moveUp(this)'>";
            htmlString += "</label><label class='fa fa-arrow-down' onclick='moveDown(this)'></label></div>";
        }
        htmlString += "</div></li>";
        $("ol#wishList").append(htmlString);

        $("ol#wishList li").sort(sort_li).appendTo('ol#wishList');
    });
    if(isUser){
        $("li").first().find("label.fa-arrow-up").addClass("hid");
        $("li").last().find("label.fa-arrow-down").addClass("hid");
    }
}

function claimItem(item){
    var itemData = new Object();
    var li = item.closest("li");

    itemData.description = $(item).find("#description").text();
    itemData.position = $(li).data("position");
    openDialog('./elements/dialog/select.dialog.html', itemData, DIALOG_TYPES.SELECT);
}

function getWishlistForGuest(listID){

        $.ajax({
            type: "GET",
            url: apiUrl + "list/guest/list/" + listID,
            contentType: "application/json;charset=utf-8",
            success: function(data){
                console.log(data);
                $("#btnAdd").addClass('hidden');
                $("span.d").addClass('hidden');
                $("#name1").text(data.firstName);
                $("#name2").text(data.secondName);

                if(data.wishlistItems != null){
                    generateList(data.wishlistItems,false);
                }
            }
        });
}






