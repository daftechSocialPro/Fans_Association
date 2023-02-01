import axios from "axios";
import React, { useEffect, useState } from "react";
import { assetUrl, urlAdvert } from "../endpoints";

function Fotter() {
  const [advert, setadvert] = useState([]);
  useEffect(() => {
    axios
      .get(urlAdvert)
      .then((res) => setadvert(res.data))
      .catch((err) => console.error(err));
  }, [advert]);

  const getImage = (item) => {
    return `${assetUrl}/${item}`;
  };
  return (
    <footer className="mainFooter">
      <div className="footerSponsorStrip">
        <ul>

       
         
            {advert.map((item, index) => (
                 <li className="">
              <a key={index} target="_blank">
                <img
                  src={getImage(item.logo)}
                  alt="Hublot"
                  style={{height: '183px',width: '100%',borderRadius: '20px'}}
                  className="footerSponsorStrip__image"
                />
                <span className="type">
                Official {item.name}
                  
                </span>
              </a>
              </li>
            ))}
          
        </ul>
      </div>

      {/* <div className="footerContent">
    <div className="wrapper">
        
        
    </div>
</div>
                                         */}
      <div
        className="footerCorporate"
        data-script="pl_footer"
        data-widget="footer-corporate"
      >
        <div className="wrapper col-12">
          <ul role="menu">
            <li>
              <strong className="" style={{ fontSize: "16px" }}>
                © የኢትዮጵያ ፕሪሚየር ሊግ ደጋፊዎች ማህበር 2015
              </strong>
            </li>
            
          </ul>
        </div>
      </div>
    </footer>
  );
}

export default Fotter;
