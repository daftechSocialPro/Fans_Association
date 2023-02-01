import React, { useState, useEffect } from "react";
import { assetUrl, urlAdvert, urlNews } from "../endpoints";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import dateformat from "dateformat";

import DOMPurify from "dompurify";
function News() {
  const [news, setNews] = useState([]);
  const [advert, setAdvert] = useState([]);
  const navigate = useNavigate();
  useEffect(() => {
    axios.get(`${urlNews}`).then((res) => {
      //"news", res.data);

      setNews(res.data);
    });

    axios.get(urlAdvert).then((res) => {
      setAdvert(res.data);
      //"ggg", res.data); 
    });
  }, []);

  const getImage = (item) => {
    return `${assetUrl}/${item}`;
  };

  const newsDetails = (e, item) => {
    e.preventDefault();
    //item);

    navigate("/news", {
      state: {
        news: item,
        newsList: news.slice(0, 6),
      },
    });
  };

  return (
    <main id="mainContent" tabIndex="0">
      <section
        data-script="pl_filtered-list"
        data-widget="filtered-content-list"
        data-page-size="10"
        data-ignore-tags="true"
        data-content-type="text"
        data-page="0"
        data-tags="News"
        data-references=""
        className="latestFeatures"
      >
        <header className="pageHero">
          <div className="wrapper col-12">
            <h2 className="pageTitle">ዜና</h2>
            <div className="searchContentContainer"></div>
            <div
              className="right"
              data-script="pl_social-share"
              data-widget="social-page-share"
              data-render="pagehover"
            ></div>
          </div>
        </header>

        <div className="wrapper col-12">
          <div className="col-8">
            <section
              className="pageFilter"
              data-use-history="true"
              data-filter-config="editorial"
              data-widget="tables-filter"
              data-reset-available="true"
            ></section>

            <ul className="newsList contentListContainer">
              {news.map((item, index) => (
                <li key={index}>
                  <section className="featuredArticle">
                    <div className="col-12-m">
                      <a
                        onClick={(e) => newsDetails(e, item)}
                        className="thumbnail thumbLong"
                      >
                        <figure>
                          <span className="image thumbCrop-news-list">
                            <img src={getImage(item.img)} alt={item.title} />
                          </span>
                          <figcaption>
                            <span className="title">{item.title}</span>

                            <span
                              className="text"
                              style={{ marginBottom: "5px" }}
                            >
                              By: {item.user.fullName} &nbsp;&nbsp; |
                              &nbsp;&nbsp; Published ON:
                              {dateformat(item.createdAt)}
                            </span>
                            <span style={{ fontSize: "12px" }} className="tag">
                              {item.subTitle}
                            </span>
                            <span className="text">
                              <div
                                dangerouslySetInnerHTML={{
                                  __html: `${DOMPurify.sanitize(
                                    item.description
                                  ).slice(0, 200)}...`,
                                }}
                              ></div>
                            </span>
                          </figcaption>
                        </figure>
                      </a>
                    </div>
                  </section>
                </li>
              ))}
            </ul>
          </div>
          <div className="col-2">
           {advert.slice(0,3).map((item,index)=>
             <div className="relatedArticles" key={index}>
             <div className="partnersStrip premiumBox">
               <img style={{width:'100%'}} src={ getImage(item.adPhoto)} />
             </div>
           </div>
           )}
          </div>
        </div>
      </section>
    </main>
  );
}

export default News;
