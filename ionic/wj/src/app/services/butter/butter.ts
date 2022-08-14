import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Butter from 'buttercms';


@Injectable({
    providedIn: 'root'
})
export class ButterService {
    public posts: any[];
    private apiKey: string = "dc04a618398e295b0f25143ebaf24b85b50a4469";
    constructor(private http: HttpClient) { }

    async getPostsList() {
        var butter = Butter(this.apiKey);
        // butter.post.retrieve('*', 'body')
        //     .then(response => console.log(response.data))
       const r = await butter.post.list({
            page: 1,
            page_size: 10,
        });
        return r;
    }

    async getPost(slug: string) {
        var butter = Butter(this.apiKey);
        // butter.post.retrieve('*', 'body')
        //     .then(response => console.log(response.data))
       const r = await butter.post.retrieve(slug);
        return r;
    }
}


