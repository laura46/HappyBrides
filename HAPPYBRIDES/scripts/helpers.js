function formatPriceString(price){
    price = price.replace(",",".");
    return parseFloat(price);
}
function sort_li(a, b){
    return ($(b).data('position')) < ($(a).data('position')) ? 1 : -1;    
}