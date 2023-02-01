import React, { useRef } from 'react'
import { CCol, CRow, CImage, CCardBody, CButton } from '@coreui/react'

import user from '../assets/user.png'
import { assetUrl } from 'src/endpoints'
import ReactToPrint from 'react-to-print'

function IdTemplate({
  headerAm,
  headerEn,
  subtitle,
  subtitle2,
  addressAm,
  address,
  lo,
  logo,
  backGroundImage,
  background,
  tempback,
  bg,
  color,
  level,
  level2,
  name,
  amharicName,
  sex,
  phoneNumber,
  userPhoto,
  idInitial,
  idno,
  backImage,
  setVisibleXLId,
  giveId,
  id
}) {
  let componentRef = useRef()
  const getImage = (item) => {
    return `${assetUrl}/${item}`
  }
  const Print = (e) => {
    e.preventDefault()
    var content = document.getElementById('printablediv')
    var pri = document.getElementById('ifmcontentstoprint').contentWindow
    pri.document.open()
    pri.document.write(content.innerHTML)

    var bootstrap = document.createElement('link')
    bootstrap.href = '@coreui/react'
    bootstrap.rel = 'stylesheet'
    pri.document.head.appendChild(bootstrap)

    pri.document.close()
    pri.focus()
    pri.print()
  }

  return (
    <>
      <iframe
        id="ifmcontentstoprint"
        style={{ height: '0px', width: '0px', position: 'absolute' }}
      ></iframe>
      <CCardBody
        ref={(el) => (componentRef = el)}
        id="printablediv"
        style={{
          backgroundColor: '#fff',
          border: ' 1px solid silver',
          padding: '20px',
          borderRadius: '20px',
          margin: '20px',
        }}
      >
        <CRow style={{ padding: '10px' }}>
          <CCol
            sm={6}
            ref={(ref) => (background = ref)}
            style={
              bg && !backGroundImage
                ? {
                    backgroundImage: `url(${getImage(bg)}) `,
                    border: '2px solid #e99313',
                    borderRadius: '17px',
                    padding: '15px',
                    backgroundRepeat: 'no-repeat',
                    backgroundSize: 'cover',
                    backgroundPosition: 'center',
                    backgroundColor: `${color ? color : '#fff'}`,
                    height: '355px'
                  }
                : backGroundImage
                ? {
                    backgroundImage: `url(${backGroundImage}) `,
                    border: '2px solid #e99313',
                    borderRadius: '17px',
                    padding: '15px',
                    backgroundRepeat: 'no-repeat',
                    backgroundSize: 'cover',
                    backgroundPosition: 'center',
                    height: '355px'
                  }
                : {
                    backgroundColor: '#232324de',
                    color: '#e99313',
                    borderRadius: '17px',
                    padding: '15px',
                    height: '355px'
                  }
            }
          >
            <CRow>
              <CCol sm={2}>
                <CImage
                  src={lo && !logo ? getImage(lo) : logo && URL.createObjectURL(logo)}
                  height={100}
                />
              </CCol>
              <CCol sm={10} style={{ textAlign: 'center' }}>
                <span style={{ fontSize: '18px', fontWeight: 'bolder' }}>{headerAm}</span>
                <br />
                <span style={{ fontSize: '16px', fontWeight: 'bold' }}>
                  {headerEn && headerEn.toUpperCase()}{' '}
                </span>
                <br />
                <span style={{ fontSize: '15px', fontWeight: 'bold' }}>{subtitle} </span>
                <br />
                <span style={{ fontSize: '15px', fontWeight: 'bold' }}>{subtitle2} </span>
                <br />
              </CCol>
            </CRow>
            <hr />

            <CRow>
              <CCol sm={6} style={{ textAlign: 'left' }}>
                <span style={{ fontSize: '17px', fontWeight: 'bolder' }}>
                  ስም &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span>{amharicName}</span>
                </span>
                <br />
                <span style={{ fontSize: '15px', fontWeight: 'bolder' }}>
                  Name &nbsp;<span>{name}</span>
                </span>
                <br />
                <br/>
              
                <CRow>
                  <CCol sm={4} style={{ textAlign: 'left' }}>
                    <span style={{ fontSize: '15px', fontWeight: 'bolder' }}>
                      ጾታ &nbsp;&nbsp;<span>{sex === 0 ? 'ወ' : sex === 1 ? 'ሴ' : ''}</span>
                    </span>
                    <br />
                    <span style={{ fontSize: '13px', fontWeight: 'bolder' }}>
                      Sex &nbsp;<span>{sex === 0 ? 'M' : sex === 1 ? 'F' : ''}</span>
                    </span>
                  </CCol>
                  <CCol sm={8} style={{ textAlign: 'center' }}>
                    <span style={{ fontSize: '18px', fontWeight: 'bolder' }}>
                      ደረጃ &nbsp;<span>{level2}</span>
                    </span>
                    <br />
                    <span style={{ fontSize: '15px', fontWeight: 'bolder' }}>
                      Level <span>{level && level.toUpperCase()}</span>
                    </span>
                  </CCol>
                </CRow>
                <br/>
                
                <span style={{ fontSize: '15px', fontWeight: 'bolder' }}>
                  አድራሻ &nbsp;&nbsp;&nbsp;&nbsp;<span>{addressAm}</span>
                </span>
                <br />
                <span style={{ fontSize: '13px', fontWeight: 'bolder' }}>
                  Address &nbsp;<span>{address && address.toUpperCase()}</span>
                </span>
              </CCol>
              <CCol sm={6} style={{ textAlign: 'right' }}>
                <span style={{ fontSize: '15px', fontWeight: 'bolder' }}>የመ.ቁ </span>{' '}
                <span style={{ fontSize: '13px', fontWeight: 'bolder' }}>
                  {idInitial} {idno}
                </span>
                <br />
                <span style={{ fontSize: '13px', fontWeight: 'bolder' }}>
                  ID.NO.{idno}
                  {idInitial}
                </span>
                <br />
                <CImage
                  src={userPhoto ? getImage(userPhoto) : user}
                  height={125}
                  style={{ border: '2px solid #daa659',borderRadius:'10px' }}
                />
                <br />
                <span style={{ fontSize: '15px', fontWeight: 'bolder' }}>ስልክ {phoneNumber}</span>
              </CCol>
            </CRow>
          </CCol>

          <CCol sm={6}>
            <CImage
              style={{
                width: '100%',
                height: '355px',
                border: '2px solid #e99313',
                borderRadius: '17px',
              }}
              src={backImage ? URL.createObjectURL(backImage) : getImage(tempback)}
            />
          </CCol>
        </CRow>
      </CCardBody>
      {name && (
        <>
        <ReactToPrint
          trigger={() => (
            <CButton
              className="mt-3"
              style={{ backgroundColor: '#232324de', color: '#e99313', borderColor: '#e99313' }}
            >
              Print
            </CButton>




          )}
          content={() => componentRef}
        />
        &nbsp;

        <CButton
              className="mt-3"
              onClick={(e)=>giveId(e,id)}
              style={{ backgroundColor: '#232324de', color: '#e99313', borderColor: '#e99313' }}
            >
              ID GIVEN
            </CButton>
            </>
      )}
    </>
  )
}

export default IdTemplate
