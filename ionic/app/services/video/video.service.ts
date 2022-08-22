import { Injectable } from '@angular/core';
import { Video } from 'src/app/interfaces/Video';

@Injectable({
  providedIn: 'root'
})
export class VideoService {
  private videos: Video[] = [
    {
      url: "../../assets/videos/intro.mp4",
      subtitle: "Wine Jargon Intro",
      thumb: "../../assets/videos/intro.jpg",
      title: "Wine Jargon Intro"
    }
  ];

  constructor() { }

  public getVidoes(): Video[] {
    return this.videos;
  }
}