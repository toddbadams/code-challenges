import { Component, OnInit } from '@angular/core';
import { ButterService } from 'src/app/services/butter/butter';

@Component({
    selector: 'wj-learn',
    templateUrl: './learn.page.html',
    styleUrls: ['./learn.page.scss'],
})
export class LearnPage implements OnInit {
    public posts: any[];
    public post: any = null;

    constructor(public butterService: ButterService) { }
    ngOnInit(): void {
        this.butterService.getPostsList()
            .then(list => {
                this.posts = list.data.data;
                console.log(this.posts);
            });
    }

    select(slug: string) {
        this.butterService.getPost(slug)
            .then(p => {
                this.post = p.data.data;
                console.log(this.post);
            })
    }
}
