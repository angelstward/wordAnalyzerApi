import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { URlS } from '../constants/url';
import { TextModel } from '../models/Text.model';

@Injectable({
  providedIn: 'root'
})
export class SenderService {  

  constructor(private http: HttpClient) { }

  public httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  public GetWords(text: TextModel): Observable<any> {    
    return this.http.post(document.getElementsByTagName('base')[0].href + URlS.PROCESSOR+URlS.SEND_TEXT,JSON.stringify(text), this.httpOptions);
  }

}
