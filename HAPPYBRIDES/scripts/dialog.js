function openDialog(dialogPath,dialogData,dialogType){
    closeDialog();
    $("html").addClass('open-dialog');
    $("body").prepend('<div class="dialog-backdrop"></div>');

    if(!dialogData){
        $(".dialog-backdrop").load(dialogPath);
    } else {
        $(".dialog-backdrop").load(dialogPath, function(){
            switch(dialogType){
                case DIALOG_TYPES.CODE:
                    $("#uniqueCode").text(dialogData);
                    break;
                case DIALOG_TYPES.EDIT:
                    $("#editDescription").val(dialogData.description);
                    $("#editPrice").val(dialogData.price);
                    $("#position").text(dialogData.position);
                    break;
                case DIALOG_TYPES.SELECT:
                    $("#itemDescription").text(dialogData.description);
                    $("#itemPosition").text(dialogData.position);
                    break;
                default:
                    console.log("in default dialog switch");

            }  
        });
    }
}
function closeDialog(){
    $(".warn").addClass('hidden');
    $("html").removeClass('open-dialog');
    $(".dialog-backdrop").remove();
}

var DIALOG_TYPES = {
    ADD: 1,
    EDIT: 2,
    CODE: 3,
    LOGIN: 4,
    REGISTER: 5,
    SELECT: 6
}