import { Component } from '@angular/core';
import { ArticlesClient } from '../web-api-client';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent {
  tez: any;
  constructor(private service: ArticlesClient) { }
  ngOnInit() {
    this.service.getArticles().subscribe(res => {
      console.log(res);
      this.tez = res;
    })
  }
  test:article[];
  articles: article[] = [
    {
      id: 1,
      writerImg: 'https://www.spectator.co.uk/wp-content/uploads/2021/01/Charles-Yu-%C2%A9-Tina-Chiou._r1.jpg',
      writer: "Son Heung-min",
      date: "29 Dec 2021",
      title: "will AI end humnaity",
      content: `But experts have rubbished the idea. "This science fiction concept is unlikely to become a reality in the coming decades if ever at all," the Stop Killer Robots campaign group wrote in a 2021 report. However, the group has warned that giving machines the power to make decisions on life and death is an existential risk.`,
      articleImg: "https://cdn.vox-cdn.com/thumbor/8l0gFhDyIR-9nZD_OAk3RILpn2E=/0x0:2743x2057/1400x1050/filters:focal(0x0:2743x2057):format(jpeg)/cdn.vox-cdn.com/uploads/chorus_image/image/37304644/Terminator-Salvation.0.0.jpg",
    },
    {
      id: 2,
      writerImg: 'https://encrypted-tbn2.gstatic.com/licensed-image?q=tbn:ANd9GcS3EHb53PF1nll3jSZceCz1LwNm2yMCHrk6vGYioyPD83pRqeJiDrnEfOVJ8yTcQnhJZsQM4wvQ0FVzzEQ',
      writer: "Christiane Amanpour",
      date: "29 Dec 2021",
      title: "Trump sues E. Jean Carroll for defamation over rape claim",
      content: `Donald Trump has sued E Jean Carroll for defamation, alleging she falsely accused him of rape after a jury in a civil trial found that he ...`,
      articleImg: "https://media.cnn.com/api/v1/images/stellar/prod/230621202747-11-donald-trump-neutral.jpg?c=16x9&q=h_720,w_1280,c_fill",
    },
    {
      id: 3,
      writerImg: 'https://www.spectator.co.uk/wp-content/uploads/2021/01/Charles-Yu-%C2%A9-Tina-Chiou._r1.jpg',
      writer: "Son Heung-min",
      date: "29 Dec 2021",
      title: "apple is raising iCloud proces in many markets - find out if you're affected",
      content: "Apple has quietly increased the prices of popular iCloud+ plans in many markets - including the UK. So, is your plan increasing?",
      articleImg: "https://images.macrumors.com/t/GkFeuDOWh_ST4JJCTMVHyVjuZ2s=/1600x0/article-new/2021/06/iCloud-General-Feature.jpg",
    },
    {
      id: 4,
      writerImg: 'https://encrypted-tbn2.gstatic.com/licensed-image?q=tbn:ANd9GcTtMphosDowiMOwlKp_1Ph5JzNGLvnnxMRbwLLYdkv_91Nupu28fZY_QmfxfMLg3hg9lcL0A8E_d3JPvLk',
      writer: "Rupert Murdoch",
      date: "29 Dec 2021",
      title: "logan roy's legacy",
      content: "What did logan roy leave behind him? can one of his kids fill his shoes? like kendall said these are big big shoes and the sibs don't seem to habe big feet",
      articleImg: "https://www.hollywoodreporter.com/wp-content/uploads/2023/05/brian-cox-H-2023.jpg?w=1296",
    },
  ]

}


interface article {
  id?: number,
  writerImg?: string,
  writer?: string,
  date?: string,
  title?: string,
  content?: string,
  articleImg?: string,
}
