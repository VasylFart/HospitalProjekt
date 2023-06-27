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
    patient: Patient;
    patientId: string;
}

export interface Patient {
    id: string;
    fullName: string;
    dateOfBirth: Date;
    pesel: string;
    address: Address;
    contact?: Contact | undefined;
    statuses: Status[];
    rooms: Room[];
    doctor: Doctor;
    doctorId: string;
    comments: Comment[];
    center: Center;
    centerId: number;
}

export interface Address {
    id: string;
    country: string;
    city?: string | undefined;
    street: string;
    numberHome: number;
    patient: Patient;
    patientId: string;
}

export interface Contact {
    id: number;
    mobilePhone?: string | undefined;
    email?: string | undefined;
    patient: Patient;
    patientId: string;
}

export interface Status {
    id: number;
    value: string;
    patient: Patient;
    patientId: string;
}

export interface Room {
    id: number;
    number: number;
    patients: Patient[];
}

export interface Doctor {
    id: string;
    fullName: string;
    patients: Patient[];
    comments: Comment[];
    center: Center;
    centerId: number;
}

export interface Comment {
    id: number;
    message: string;
    createdDate: Date;
    updatedDate?: Date | undefined;
    doctor: Doctor;
    doctorId: string;
    patient: Patient;
    patientId: string;
}

export interface Center {
    id: number;
    name: string;
    patients: Patient[];
    doctors: Doctor[];
}

export interface PostAddressDto {
    country: string;
    city?: string | undefined;
    street: string;
    numberHome: number;
    patientId: string;
}

export interface CenterDto {
    id: number;
    name: string;
    address: Address;
}

export interface PostCenterDto {
    name: string;
}

export interface CommentDto {
    id: number;
    message: string;
    createdDate: Date;
    updatedDate?: Date | undefined;
    doctor: Doctor;
    doctorId: string;
    patient: Patient;
    patientId: string;
}

export interface PostCommentDto {
    message: string;
    createdDate: Date;
    updatedDate?: Date | undefined;
    doctorId: string;
    patientId: string;
}

export interface ContactDto {
    id: number;
    mobilePhone?: string | undefined;
    email?: string | undefined;
    patient: Patient;
    patientId: string;
}

export interface PostContactDto {
    mobilePhone?: string | undefined;
    email?: string | undefined;
    patientId: string;
}

export interface DoctorDto {
    id: string;
    fullName: string;
    patients: Patient[];
    comments: Comment[];
    center: Center;
    centerId: string;
}

export interface PostDoctorDto {
    fullName: string;
    patients: Patient[];
    comments: Comment[];
    centerId: string;
}

export interface RoomDto {
    id: number;
    number: number;
    patients: Patient[];
}

export interface PostRoomDto {
    number: number;
    patients: Patient[];
}

export interface FileResponse {
    data: Blob;
    status: number;
    fileName?: string;
    headers?: { [name: string]: any };
}