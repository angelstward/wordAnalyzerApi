import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { URlS } from '../constants/url';
import { TextModel } from '../models/Text.model';

@Injectable({
  providedIn: 'root'
})
export class SenderService { 
  public httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }   

  constructor(private http: HttpClient) { }

  
  httpHeaders: HttpHeaders = this.httpOptions.headers;

  public GetWords(text: TextModel): Observable<any> {    
    const token = localStorage.getItem('token');
    this.httpHeaders.append('Authorization', 'Bearer' + token);   
    return this.http.post(document.getElementsByTagName('base')[0].href + URlS.PROCESSOR+URlS.SEND_TEXT,JSON.stringify(text), {headers: this.httpHeaders});
  }

  public GetToken(text: TextModel) :Observable<any>{
    return this.http.post(document.getElementsByTagName('base')[0].href + URlS.AUTH,JSON.stringify(text), this.httpOptions);
  }

}
