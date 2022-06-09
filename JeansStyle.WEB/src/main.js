// Dependencies
import {createApp} from 'vue'
import Swal from "sweetalert2";

// Components
import CartComponent from "@/components/Cart/CartComponent";
import AddToCartButton from "@/components/Cart/AddToCartButton";
import ProductCard from "@/components/Catalog/ProductCard";

let app = createApp({
    components: {
        CartComponent,
        AddToCartButton,
        ProductCard,
    },
})

app.mount('#app')

export const Toast = Swal.mixin({
    toast: true,
    position: 'top-end',
    showConfirmButton: false,
    timer: 3000,
    timerProgressBar: true,
    didOpen: (toast) => {
        toast.addEventListener('mouseenter', Swal.stopTimer)
        toast.addEventListener('mouseleave', Swal.resumeTimer)
    }
})

export function toastMsg(icon, title) {
    Toast.fire({
        icon: icon,
        title: title
    })
}

export function toastSuccess(title) {
    toastMsg('success', title)
}