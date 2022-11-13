import axios from "axios"

export const baseURL = 'https://localhost:7159/'

const instanse =  axios.create({
    baseURL: baseURL,
})

export default instanse