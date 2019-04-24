import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Comic } from '../_models/comic';

@Injectable({
  providedIn: 'root'
})
export class ComicService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getComics(): Observable<Comic[]> {
    return this.http.get<Comic[]>(this.baseUrl + 'comics');
  }

  getComic(id): Observable<Comic> {
    return this.http.get<Comic>(this.baseUrl + 'comics/' + id);
  }

  deleteComic(id): Observable<Comic> {
    return this.http.delete<Comic>(this.baseUrl + 'comics/' + id);
  }

  addComic(model: any) {
    return this.http.post(this.baseUrl + 'comics/addcomic', model);
  }


}
