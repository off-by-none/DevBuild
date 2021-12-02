//******* TALLEST MOUNTAIN *******//
/**
 * Finds the tallest mountain from an array of mountains.
 * @param mountains array of mountain objects.
 * @returns returns string name of the mountain with the greatest height.
 */
function findNameOfTallestMountain(mountains) {
    var tallestMountain = { name: 'None', height: 0 };
    if (mountains.length > 0) {
        for (var _i = 0, mountains_1 = mountains; _i < mountains_1.length; _i++) {
            var m = mountains_1[_i];
            if (m.height > tallestMountain.height) {
                tallestMountain = m;
            }
        }
    }
    return tallestMountain.name;
}
var mountain01 = {
    name: 'Kilimanjaro',
    height: 19341
};
var mountain02 = {
    name: 'Everest',
    height: 29029
};
var mountain03 = {
    name: 'Denali',
    height: 20310
};
var mountains = [mountain01, mountain02, mountain03];
var tallestMountain = findNameOfTallestMountain(mountains);
console.log('\x1b[1;35m%s\x1b[0m', "Tallest Mountain: " + tallestMountain);
console.log();
//******* PRODUCTS *******//
/**
 * @param products array of product objects.
 * @returns returns number, the average price of all products.
 */
function calcAverageProductPrice(products) {
    var sum = 0;
    var averagePrice = 0;
    if (products.length > 0) {
        for (var _i = 0, products_1 = products; _i < products_1.length; _i++) {
            var p = products_1[_i];
            sum += p.price;
        }
        averagePrice = sum / products.length;
    }
    return averagePrice;
}
var product01 = {
    name: 'Motor',
    price: 10.00
};
var product02 = {
    name: 'Sensor',
    price: 12.50
};
var product03 = {
    name: 'LED',
    price: 1.00
};
var products = [product01, product02, product03];
var averagePrice = calcAverageProductPrice(products);
console.log('\x1b[1;35m%s\x1b[0m', "Average Price: $" + averagePrice.toFixed(2));
console.log();
//******* INVENTORY *******//
/**
 * @param inventory array of InventoryItem objects.
 * @returns returns number, the total value of the inventory.
 */
function calcInventoryValue(inventory) {
    var inventoryValue = 0;
    if (products.length > 0) {
        for (var _i = 0, inventory_1 = inventory; _i < inventory_1.length; _i++) {
            var prod = inventory_1[_i];
            inventoryValue += (prod.product.price * prod.quantity);
        }
    }
    return inventoryValue;
}
var inventory01 = {
    product: product01,
    quantity: 10
};
var inventory02 = {
    product: product02,
    quantity: 4
};
var inventory03 = {
    product: product03,
    quantity: 20
};
var inventory = [inventory01, inventory02, inventory03];
var inventoryValue = calcInventoryValue(inventory);
console.log('\x1b[1;35m%s\x1b[0m', "Inventory Value: $" + inventoryValue.toFixed(2));
console.log();
