import { Byte } from "@angular/compiler/src/util";

export interface User {
    cod?: number
    fullName: string
    userName: string
    password: string
    mobile: string
    email: string
    userType: string
    profilePicture: string
    publicIdPicture: string
    isLogged: Byte
}