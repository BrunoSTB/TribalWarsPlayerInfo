import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import {Player} from '../_interfaces/player'

@Injectable({
  providedIn: 'root'
})
export class PlayerSearchService {

  private readonly baseUrl = 'https://localhost:7165';
  private readonly endpoint = '/PlayerInformationExtractor';

  constructor(private http: HttpClient) { }

  public CheckHealth(): Observable<any> {
    return this.http.get<any>(this.baseUrl + this.endpoint);
  }

  public GetPlayerClassificationInfo(parameters: string): Observable<any> {
    const requestUrl = this.baseUrl + this.endpoint + parameters;
    return this.http.get<Player>(requestUrl);
  }
}
