//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.18.2.0 (NJsonSchema v10.8.0.0 (Newtonsoft.Json v10.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------

/* tslint:disable */
/* eslint-disable */
// ReSharper disable InconsistentNaming



export interface PatientDto {
    id: string;
    fullName: string;
    age: number;
    dateOfBirth: Date;
    pesel: string;
}

export interface PostPatientDto {
    fullName: string;
    dateOfBirth: Date;
    pesel: string;
}

export interface AddressDto {
    id: string;
    country: string;
    city?: string | undefined;
    street: string;
    numberHome: number;
}

export interface PostAddressDto {
    country: string;
    city?: string | undefined;
    street: string;
    numberHome: number;
}

export interface CenterDto {
    id: number;
    name: string;
}

export interface PostCenterDto {
    name: string;
}

export interface CommentDto {
    id: number;
    message: string;
    createdDate: Date;
    updatedDate?: Date | undefined;
}

export interface PostCommentDto {
    message: string;
    createdDate: Date;
    updatedDate?: Date | undefined;
}

export interface ContactDto {
    id: number;
    mobilePhone?: string | undefined;
    email?: string | undefined;
}

export interface PostContactDto {
    mobilePhone?: string | undefined;
    email?: string | undefined;
}

export interface DepartmentDto {
    id: number;
    value: string;
}

export interface PostDepartmentDto {
    value: string;
}

export interface DoctorDto {
    id: string;
    fullName: string;
}

export interface PostDoctorDto {
    fullName: string;
}

export interface RoomDto {
    id: number;
    number: number;
}

export interface PostRoomDto {
    number: number;
}

export interface FileResponse {
    data: Blob;
    status: number;
    fileName?: string;
    headers?: { [name: string]: any };
}