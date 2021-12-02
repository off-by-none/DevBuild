//******* TALLEST MOUNTAIN *******//
/**
 * Finds the tallest mountain from an array of mountains.
 * @param mountains array of mountain objects.
 * @returns returns string name of the mountain with the greatest height.
 */
function findNameOfTallestMountain(mountains:Mountain[]):string {
    let tallestMountain:Mountain = {name: 'None', height: 0};
    
    if (mountains.length > 0){    
        for (let m of mountains){
            if (m.height > tallestMountain.height){
                tallestMountain = m;
            }
        }
    }

    return tallestMountain.name;
}

interface Mountain {
    name:string;
    height:number
}

let mountain01:Mountain = {
    name: 'Kilimanjaro',
    height: 19341
}

let mountain02:Mountain = {
    name: 'Everest',
    height: 29029
}

let mountain03:Mountain = {
    name: 'Denali',
    height: 20310
}

let mountains:Mountain[] = [mountain01, mountain02, mountain03];

let tallestMountain:string = findNameOfTallestMountain(mountains);

console.log('\x1b[1;35m%s\x1b[0m', `Tallest Mountain: ${tallestMountain}`);
console.log();



//******* PRODUCTS *******//
/**
 * @param products array of product objects.
 * @returns returns number, the average price of all products.
 */
function calcAverageProductPrice(products:Product[]):number {
    let sum:number = 0;
    let averagePrice:number = 0;
    
    if (products.length > 0){    
        for (let p of products){
            sum += p.price;
            }
        averagePrice = sum / products.length;
        }
    
    return averagePrice;
}

interface Product {
    name:string;
    price:number
}

let product01:Product = {
    name: 'Motor',
    price: 10.00
}

let product02:Product = {
    name: 'Sensor',
    price: 12.50
}

let product03:Product = {
    name: 'LED',
    price: 1.00
}

let products:Product[] = [product01, product02, product03];

let averagePrice:number = calcAverageProductPrice(products);

console.log('\x1b[1;35m%s\x1b[0m', `Average Price: $${averagePrice.toFixed(2)}`);
console.log();


//******* INVENTORY *******//
/**
 * @param inventory array of InventoryItem objects.
 * @returns returns number, the total value of the inventory.
 */
function calcInventoryValue(inventory:InventoryItem[]):number {
    let inventoryValue:number = 0;
    
    if (products.length > 0){    
        for (let prod of inventory){
            inventoryValue += (prod.product.price * prod.quantity);
            }
        }
    
    return inventoryValue;
}

interface InventoryItem {
    product:Product,
    quantity:number
}

let inventory01:InventoryItem = {
    product: product01,
    quantity: 10
}

let inventory02:InventoryItem = {
    product: product02,
    quantity: 4
}

let inventory03:InventoryItem = {
    product: product03,
    quantity: 20
}

let inventory:InventoryItem[] = [inventory01, inventory02, inventory03];

let inventoryValue:number = calcInventoryValue(inventory);

console.log('\x1b[1;35m%s\x1b[0m', `Inventory Value: $${inventoryValue.toFixed(2)}`);
console.log();