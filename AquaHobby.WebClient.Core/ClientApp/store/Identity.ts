import { fetch, addTask } from 'domain-task';
import { Action, Reducer, ActionCreator } from 'redux';
import { AppThunkAction } from './';
import { ClientApi } from './ApiProxy';

export interface IdentityState {
    IsLogged: boolean,
    UserName: string,
    UserId: string
}


const defaultIdentityState: IdentityState = {
    IsLogged: false,
    UserId: "",
    UserName: ""
}