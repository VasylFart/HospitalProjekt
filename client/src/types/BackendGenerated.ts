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
    address: AddressDto;
    contact?: ContactDto | undefined;
    statuses: StatusDto[];
    rooms: RoomDto[];
    doctor: DoctorDto;
    comments: CommentDto[];
    center: CenterDto;
}

export interface AddressDto {
    id: string;
    country: string;
    city?: string | undefined;
    street: string;
    numberHome: number;
    patient: PatientDto;
}

export interface ContactDto {
    id: number;
    mobilePhone?: string | undefined;
    email?: string | undefined;
    patient: PatientDto;
}

export interface StatusDto {
    id: number;
    value: string;
    patient: PatientDto;
}

export interface RoomDto {
    id: number;
    number: number;
    patients: PatientDto[];
}

export interface DoctorDto {
    id: string;
    fullName: string;
    patients: PatientDto[];
    center: CenterDto;
}

export interface CenterDto {
    id: number;
    name: string;
    patients: PatientDto[];
    doctors: DoctorDto[];
}

export interface CommentDto {
    id: number;
    message: string;
    createdDate: Date;
    updatedDate?: Date | undefined;
    doctor: DoctorDto;
    patient: PatientDto;
}

export interface PostPatientDto {
    fullName: string;
    dateOfBirth: Date;
    pesel: string;
}

export interface PostAddressDto {
    country: string;
    city?: string | undefined;
    street: string;
    numberHome: number;
}

export interface PostCenterDto {
    name: string;
}

export interface PostCommentDto {
    message: string;
    createdDate: Date;
    updatedDate?: Date | undefined;
}

export interface PostContactDto {
    mobilePhone?: string | undefined;
    email?: string | undefined;
}

export interface PostDoctorDto {
    fullName: string;
}

export interface PostRoomDto {
    number: number;
}

export interface PostStatusDto {
    value: string;
    patient: PatientDto;
    statistic: StatisticDto;
}

export interface StatisticDto {
    id: number;
    doctors: DoctorDto[];
    patients: PatientDto[];
    statuss: StatusDto[];
    rooms: RoomDto[];
}

export interface FileResponse {
    data: Blob;
    status: number;
    fileName?: string;
    headers?: { [name: string]: any };
}