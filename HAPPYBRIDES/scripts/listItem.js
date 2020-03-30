function claimListItem(){
    var elements = [$("#claimerName"), $("#claimerText")];
    if(checkForm(elements)){
        var request = new Object();
        request.Name = elements[0].val();
        request.Message = elements[1].val();
        request.Position = parseInt($("#itemPosition").text());
        request.Description = $("#itemDescription").text();
        request.ListID = parseInt(getListID());
        console.log(request);
        $.ajax({
            type: "PUT",
            url: apiUrl + "list/claim",
            contentType: "application/json;charset=utf-8",
            data: JSON.stringify(request),
            success: function(data){
                console.log(data);
                if(data){
                    closeDialog();
                    getWishlistForGuest(parseInt(getListID()));
                }
        
            }
        });
    }
}

function selectItem(item){
    var itemData = new Object();
    var li = item.closest("li");
    itemData.position = $(li).index() + 1;
    itemData.price = $(item).find("#price").text();
    itemData.description = $(item).find("#description").text();

    openDialog("./elements/dialog/edit.dialog.html",itemData,DIALOG_TYPES.EDIT);
}
function deleteItem(){
    var pos = parseInt($("#position").text());
    var list = parseInt(sessionStorage.getItem("listID"));
    $.ajax({
        type: "DELETE",
        url: apiUrl + "list/" + list + "/" + pos,
        contentType: "application/json;charset=utf-8",
        success: function(data){
            console.log(data);
            if(data){
                getWishlistForCouple(getCoupleID());
                closeDialog();
            }
    
        }
    });
}
function editItem(){
    var request = new Object();
    request.Description = $("#editDescription").val();
    request.Price = formatPriceString($("#editPrice").val());
    request.Position = parseInt($("#position").text());
    request.ListID = parseInt(sessionStorage.getItem("listID"));
    $.ajax({
        type: "PUT",
        url: apiUrl + "list/edit",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(request),
        success: function(data){

            if(data){
                getWishlistForCouple(getCoupleID());
                closeDialog();
            }
    
        }
    });
}
function addItem(){
    var request = new Object();
    request.Description = $("#addDescription").val();
    request.Price = formatPriceString($("#addPrice").val());
    request.Position = ($('#wishList li').length > 0) ? parseInt($('#wishList li').last().data("position")) + 1 : 1;
    request.CoupleID = parseInt(getCoupleID());
    $.ajax({
        type: "POST",
        url: apiUrl + "list/add",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(request),
        success: function(data){
            if(data){
                getWishlistForCouple(request.CoupleID);
                closeDialog();
            }
        }
    });
}
function moveUp(item){
    var request = new Object();
    var li = item.closest("li");
    request.Description = $(li).find("#description").text();
    request.Price = formatPriceString($(li).find("#price").text());
    request.Position = $(li).data("position");
    request.ListID = parseInt(sessionStorage.getItem("listID"));
    $.ajax({
        type: "PUT",
        url: apiUrl + "list/up",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(request),
        success: function(data){
            if(data){
                getWishlistForCouple(getCoupleID());
                closeDialog();
            }
    
        }
    });
}
function moveDown(item){
    var request = new Object();
    var li = item.closest("li");
    request.Description = $(li).find("#description").text();
    request.Price = formatPriceString($(li).find("#price").text());
    request.Position = $(li).data("position");
    request.ListID = parseInt(sessionStorage.getItem("listID"));
    $.ajax({
        type: "PUT",
        url: apiUrl + "list/down",
        contentType: "application/json;charset=utf-8",
        data: JSON.stringify(request),
        success: function(data){
            if(data){
                getWishlistForCouple(getCoupleID());
                closeDialog();
            }
    
        }
    });
}