import React, { useEffect, useState } from "react";
import axios from "axios";
import { assetUrl, urlAdvert, urlMahber, urlMahberExec } from "../endpoints";

function Mahber() {
  const [mahber, setMahber] = useState([]);
  const [index, setIndex] = useState(0);
  const [mahberMember, setMahberMember] = useState([]);
  const [ma, setMa] = useState([]);
  const [advert, setAdvert] = useState([]);

  useEffect(() => {
    axios
      .get(urlMahber)
      .then((res) => {
        //res.data);

        setMahber(res.data);
        setMa(res.data[0] && res.data[0]);
        //"maa", ma);
        getMahber(res.data[0] && res.data[0].id);
      })
      .catch((err) => console.error(err));


      axios.get(urlAdvert).then((res) => {
        setAdvert(res.data);
        //"ggg", res.data);
      });


  }, []);

  const getImage = (item) => {
    return `${assetUrl}/${item}`;
  };

  const getMahber = (item) => {
    axios
      .get(`${urlMahberExec}/?mahberId=${item}`)
      .then((res) => setMahberMember(res.data))
      .catch((err) => console.error(err));
  };

  return (
    <div>
      <main id="mainContent" tabIndex="0">
        <header className="pageHero tabbedHero">
          <div className="wrapper col-12">
            <h1 className="pageTitle">ማህበራት</h1>
          </div>
          <nav className="heroPageLinks tabLinks" data-widget="referee-tabs">
            <ul className="wrapper col-12">
              {mahber.map((item, ind) => (
                <li key={ind} data-nav-index="menuItem?index">
                  <a
                    onClick={(e) => {
                      setIndex(ind);
                      getMahber(item.id);
                      setMa(item);
                    }}
                    className={index == ind ? "btn-tab active" : "btn-tab"}
                  >
                    {item.name}
                  </a>
                </li>
              ))}
            </ul>
          </nav>
        </header>

        <div className="wrapper col-12">

          <div className="col-9-m">
          <section className="featuredArticle">
            {ma && (
              <>
              
              <div className="col-12-m">
                <a className="thumbnail thumbLong">
                  <figure>
                    <span className="image thumbCrop-news-list"  style={{ width: "20%" }}>
                      <img src={ma && getImage(ma.logo)} alt={ma&&ma.name} />
                    </span>
                    <figcaption>
                      <span className="title">{ma && ma.name}</span>
                      <span className="tag">
                        Established Date {ma && ma.establishedDate}
                      </span>
                      <span className="text">
                        <div
                          dangerouslySetInnerHTML={{
                            __html: ma && ma.description,
                          }}
                        ></div>
                      </span>
                    </figcaption>
                  </figure>
                </a>
              </div>
           
              </>
            )}
          </section>

          <section className="mainWidget latestFeatures ">
            <header>
              <h3 className="subHeader">የማህበሩ ስራ አስፈጻሚዎች</h3>
            </header>

            <ul className="block-list-4" data-widget="lazy-load">
              {mahberMember.map((item) => (
                <li
                  className="article-thumb placeholder js-content-load"
                  data-initialised="false"
                >
                  <a className="thumbnail">
                    <figure>
                      <span className="image thumbCrop-latestnews" style={{borderRadius:'20px'}}>
                        <img
                          className="article-thumb__img"
                          src={getImage(item.userPhoto)}
                          alt={item.name}
                        />
                      </span>
                      <figcaption>
                        <span className="tag">አባላት</span>
                        <span className="title">{item.name}</span>
                      </figcaption>
                    </figure>
                  </a>
                  <div className="relatedArticles">
                    <a
                     
                      className="relatedArticle club text"
                    >
                      <p>Postition: {item.position}</p>
                    </a>

                    <a
                   
                      className="relatedArticle club text"
                    >
                      <p>
                        From Date :{item.fromDate} - To Date : {item.toDate}
                      </p>
                    </a>
                  </div>
                </li>
              ))}
            </ul>
          </section>
          </div>
          {/* <div className="col-2-m">
           {advert.slice(0,2).map((item,index)=>
             <div className="relatedArticles" key={index}>
             <div className="partnersStrip premiumBox">
               <img src={ getImage(item.adPhoto)} />
             </div>
           </div>
           )}
          </div> */}
          
        </div>
      </main> 
    </div>
  );
}

export default Mahber;



