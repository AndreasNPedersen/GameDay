import React from 'react';
const baseUrl= "http://194.35.13.218:5400/api/";
//https://jasonwatmore.com/post/2020/02/01/react-fetch-http-post-request-examples
//const baseUrl = "https://localhost:44394/api/"
export  const  FetchPost = async (bodyInput:any) => {
    return await fetch(baseUrl+"login/login",{
        method:"POST",
        headers: {
            'Content-Type': 'application/json',
          },
        body: JSON.stringify(bodyInput) 
    }).then((response) => response) 
}

export  const  FetchPostCreate = async (bodyInput:any) => {
    return await fetch(baseUrl+"login/create",{
        method:"POST",
        headers: {
            'Content-Type': 'application/json',
          },
        body: JSON.stringify(bodyInput) 
    }).then((response) => response) 
}

export  const  FetchPostCreateGroup = async (bodyInput:any) => {
    return await fetch(baseUrl+"groups",{
        method:"POST",
        headers: {
            'Content-Type': 'application/json',
          },
        body: JSON.stringify(bodyInput) 
    }).then((response) => response) 
}

export const FetchGet = () => {
    return fetch(baseUrl+"login",{
        method:"Get",
        headers: {
            'Content-Type': 'application/json',
          },
    }).then((response) => response)
}

export const FetchGetGroups = () => {
    return fetch(baseUrl+"Groups",{
        method:"Get",
        headers: {
            'Content-Type': 'application/json',
          },
    }).then((response) => response)
}

export const FetchGetGroup = (id:any) => {
    return fetch(baseUrl+"Groups/"+id,{
        method:"Get",
        headers: {
            'Content-Type': 'application/json',
          },
    }).then((response) => response)
}

export const FetchGetGames = () => {
    return fetch(baseUrl+"games",{
        method:"Get",
        headers: {
            'Content-Type': 'application/json',
          },
    }).then((response) => response)
}

export const FetchGetGroupsAttendees = (id:any) => {
    return fetch(baseUrl+"Groups/GetGroupAttendees?GroupId="+id,{
        method:"Get",
        headers: {
            'Content-Type': 'application/json',
          },
    }).then((response) => response)
}

export const FetchPostJoinGroup = (idGroup:any,idUser:any) => {
    const bodyInput = {
        "groupId": idGroup,
        "userId": idUser
      }
    return fetch(baseUrl+"Groups/join",{
        method:"POST",
        headers: {
            'Content-Type': 'application/json',
          },
        body: JSON.stringify(bodyInput) 
    }).then((response) => response)
}

export const FetchPostLeaveGroup = (idGroup:any,idUser:any) => {
    const bodyInput = {
        "groupId": idGroup,
        "userId": idUser
      }
    return fetch(baseUrl+"Groups/unjoin",{
        method:"POST",
        headers: {
            'Content-Type': 'application/json',
          },
        body: JSON.stringify(bodyInput) 
    }).then((response) => response)
}

export const FetchGetDeleteGroup = (id:any) => {
    return fetch(baseUrl+"groups/"+id,{
        method:"Delete",
        headers: {
            'Content-Type': 'application/json',
          },
    }).then((response) => response)
}