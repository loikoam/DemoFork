import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SearchRequest } from '../components/search-request/search-request.component';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class YoutubeService {

  resultSubject = new Subject<ResultVideo[]>();
  result$ = this.resultSubject.asObservable();


  constructor(private client: HttpClient) { }

  searchVideo(searchRequest: SearchRequest) {
    return this.client.post<ResultVideo[]>('http://localhost:60601/api/SearchRequest', searchRequest);
  }
  getStory() {
   // return this.client.get<SearchStory[]>('http://localhost:60601/api/story');
  }


}
export interface SearchStory {
    Id: number;
    SearchDate: Date;
    UserId: string;
    SearchRequest_Id: number;
  }

export interface ResultVideo {
  Id: string;
  Title: string;
  Description: string;
  PublishedAt: Date;
  Definition: string;
  Dimension: string;
  Duration: string;
  VideoCaption: string;
  Thumbnail: string;
  Channel: {
    Id: string;
    Name: string;
  };
  Channel_Id: string;
}
