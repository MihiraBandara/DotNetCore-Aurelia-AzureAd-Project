import {HttpConfig} from './http-config';
import {HttpClient} from 'aurelia-fetch-client';
import {inject} from 'aurelia-framework';
import {Auth} from './auth';
import settings from './settings';

@inject(Auth, HttpConfig, HttpClient)
export class App {
  accountList : any[];
  httpConfig : HttpConfig;
  httpClient : HttpClient;
  auth : Auth;

  constructor(auth : Auth, httpConfig : HttpConfig, httpClient : HttpClient) {
    this.auth = auth;
    this.httpClient = httpClient;
    this.httpConfig = httpConfig;
    this
      .httpConfig
      .configure();
  }

  activate() {
    return this
      .httpClient
      .fetch(settings.service + 'AccountDetails')
      .then((response) => {
        return response
          .json()
          .then((data) => {
            this.accountList = data;
          });
      });
  }

  logout() {
    this
      .auth
      .logout();
  }
}
