import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../constants/Constants';
import { OpinionCreation } from 'src/app/client/models/OpinionCreation';
import { Opinion } from '../models/Opinion';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OpinionService {

  private baseUrl = Constants.SERVER_BASE_URL + 'opinion/';

  constructor(private http: HttpClient) { }

  addOpinion(opinion: OpinionCreation): Observable<Opinion> {
    return this.http.post<Opinion>(this.baseUrl, opinion);
  }

  updateAnswer(opinionId: string, answer: string) {
    return this.http.put(this.baseUrl + opinionId + '/update-answer', {id: opinionId, answer: answer});
  }

  deleteOpinion(opinionId: string) {
    return this.http.delete(this.baseUrl + opinionId);
  }

}
