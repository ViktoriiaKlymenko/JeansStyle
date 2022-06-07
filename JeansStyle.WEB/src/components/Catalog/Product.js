import {Gender} from "@/components/Catalog/Gender";

export class Product {
    constructor(
        id,
        title,
        image,
        description,
        price,
        gender
    ) {
        this.id = id
        this.title = title
        this.image = image
        this.description = description
        this.price = parseFloat(price).toFixed(2)

        gender = {id: 'sad', name: '123'}
        this.gender = new Gender(gender)
    }
}