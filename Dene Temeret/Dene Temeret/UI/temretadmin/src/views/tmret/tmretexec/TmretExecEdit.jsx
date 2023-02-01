import React, { useState, useEffect } from 'react'
import ReactQuill, { Quill } from 'react-quill'
import 'react-quill/dist/quill.snow.css'
import ImageResize from 'quill-image-resize-module-react'
import { customToast } from '../../../components/customToast'
import axios from 'axios'
import { useNavigate } from 'react-router-dom'
Quill.register('modules/imageResize', ImageResize)
import { MDBCol, MDBRow, MDBCard, MDBCardText, MDBCardBody, MDBCardImage } from 'mdb-react-ui-kit'
import { useLocation } from 'react-router-dom'

import {
  CCard,
  CCardHeader,
  CRow,
  CCol,
  CCardBody,
  CCallout,
  CButton,
  CFormInput,
  CFormLabel,
  CFormSwitch,
  CForm,
} from '@coreui/react'
import { assetUrl, urlTmretExec } from '../../../endpoints'


function TmretExecEdit({ user ,setIsLodding}) {
  const location = useLocation()

  const tmretExec = location.state.tmret

  //tmretExec)

  const [img, setImg] = useState('')
  const [description, setDescription] = useState(tmretExec.description)
  const [fullName, setFullName] = useState(tmretExec.name)
  const [position, setPosition] = useState(tmretExec.position)
  const [birthDate, setBirthDate] = useState(tmretExec.birthDate)
  const [fromDate, setFromDate] = useState(tmretExec.fromDate)
  const [toDate, setToDate] = useState(tmretExec.toDate);
  const [isActive,setIsActive]=useState(tmretExec.isActive);



  const navigate = useNavigate()

  const photoInputHandler = (event) => {
    setImg(event.target.files[0])
  }

  const handleSubmit = async (event) => {
    
    event.preventDefault()

    const formData = new FormData()

    //user)
    formData.append('Photo', img)
    formData.set('name', fullName)
    formData.set('position', position)
    formData.set('birthDate', birthDate)
    formData.set('fromDate', fromDate)
    formData.set('toDate', toDate)
    formData.set('Description', description)
    formData.set('temretId', user.id)
    formData.set("ID",tmretExec.id)
    formData.set("IsActive",isActive)

    const form = event.currentTarget
    if (form.checkValidity() === false) {
      event.stopPropagation()
    }
    try {
      setIsLodding(true)
      axios.defaults.withCredentials = true
      axios
        .put(urlTmretExec, formData)
        .then((res) => {
          setIsLodding(false)
          navigate('/tmretexec')
          customToast('Tmret Executives Successfully updated', 0)
        })
        .catch((err) => {
          setIsLodding(false)
          alert(err)
          console.error(err)
        })
    } catch (error) {
      setIsLodding(false)
      customToast(error, 1)
      console.error(error)
    }
  }

  const modules = {
    toolbar: [
      [{ header: '1' }, { header: '2' }, { font: [] }],
      [{ size: [] }],
      ['bold', 'italic', 'underline', 'strike', 'blockquote'],
      [{ list: 'ordered' }, { list: 'bullet' }, { indent: '-1' }, { indent: '+1' }],
      ['link', 'image', 'video'],
      ['clean'],
    ],
    clipboard: {
      matchVisual: false,
    },
    imageResize: {
      parchment: Quill.import('parchment'),
      modules: ['Resize', 'DisplaySize'],
    },
  }

  const formats = [
    'header',
    'font',
    'size',
    'bold',
    'italic',
    'underline',
    'strike',
    'blockquote',
    'list',
    'bullet',
    'indent',
    'link',
    'image',
    'video',
  ]
  const getImage = (item) => {
    return `${assetUrl}/${item}`
  }

  return (
    
    <CRow>
      <CCol xs={12}>
        <CCallout className="bg-white"></CCallout>
      </CCol>
      <CCol xs={12}>
        <CCard className="mb-4">
          <CCardHeader style={{ backgroundColor: '#232324de', color: '#e99313' }} className="">
            <CRow>
              <CCol sm={10}>
                <strong>Tmret Executives</strong> <small>Update Profile</small>
              </CCol>
            </CRow>
          </CCardHeader>
          <CForm validated onSubmit={handleSubmit}>
            <CCardBody>
              <MDBRow>
                <MDBCol lg="4">
                  <MDBCard className="mb-4">
                    <MDBCardBody className="text-center">
                      <MDBCardImage
                        src={img ? URL.createObjectURL(img) : getImage(tmretExec.userPhoto)}
                        alt="avatar"
                        style={{ width: '280px', borderRadius: '20px', border: 'solid #e99313' }}
                        fluid
                      />

                      <div className="d-flex justify-content-center mb-10">
                        <CCol md={4}>
                          <CFormLabel htmlFor="formFileLg">Photo</CFormLabel>
                          <CFormInput
                            type="file"
                            size="sm"
                            accept="image/*"
                            onChange={photoInputHandler}
                            
                            id="formFileLg"
                          />
                     
                        </CCol>
                      </div>
                     
                    </MDBCardBody>
                  </MDBCard>
                </MDBCol>

                <MDBCol lg="8">
                  <MDBCard className="mb-4">
                    <MDBCardBody>
                      <MDBRow>
                        <MDBCol sm="3">
                          <MDBCardText>Full Name</MDBCardText>
                        </MDBCol>
                        <MDBCol sm="9">
                          <CFormInput
                            type="text"
                            placeholder="full name ..."
                            required
                            value={fullName}
                            onChange={(e) => setFullName(e.target.value)}
                          />
                        </MDBCol>
                       
                      </MDBRow>
                      <hr />
                      <MDBRow>
                        <MDBCol sm="3">
                          <MDBCardText>Position</MDBCardText>
                        </MDBCol>
                        <MDBCol sm="9">
                          <CFormInput
                            type="text"
                            placeholder="position..."
                            required
                            value={position}
                            onChange={(e) => setPosition(e.target.value)}
                          />
                        </MDBCol>
                      </MDBRow>
                      <hr />
                      <MDBRow>
                        <MDBCol sm="3">
                          <MDBCardText>Date of Birth</MDBCardText>
                        </MDBCol>
                        <MDBCol sm="9">
                          <CFormInput
                            type="date"
                            placeholder="date of birth ..."
                            required
                            value={birthDate}
                            onChange={(e) => setBirthDate(e.target.value)}
                          />
                        </MDBCol>
                      </MDBRow>
                      <hr />
                      <MDBRow>
                        <MDBCol sm="3">
                          <MDBCardText>From Date - To Date</MDBCardText>
                        </MDBCol>
                        <MDBCol sm="9">
                          <MDBRow>
                            <MDBCol sm="6">
                              <CFormInput
                                type="date"
                                placeholder="from date ..."
                                required
                                value={fromDate}
                                onChange={(e) => setFromDate(e.target.value)}
                              />
                            </MDBCol>
                            <MDBCol sm="6">
                              <CFormInput
                                type="date"
                                placeholder="link ..."
                                required
                                value={toDate}
                                onChange={(e) => setToDate(e.target.value)}
                              />
                            </MDBCol>
                          </MDBRow>
                        </MDBCol>
                      </MDBRow>
                      <MDBRow>
                        <MDBCol sm="3">
                        <CFormSwitch  checked={isActive} onChange={()=>setIsActive(!isActive)}  label="Is User Active" />
                        </MDBCol>
                        </MDBRow>
                     
                      <hr />

                      <MDBRow>
                        <MDBCol sm="3">
                          <MDBCardText>Description</MDBCardText>
                        </MDBCol>

                        <MDBCol sm="9">
                          <ReactQuill
                            formats={formats}
                            modules={modules}
                            theme="snow"
                            required
                            value={description}
                            onChange={setDescription}
                          />
                        </MDBCol>
                      </MDBRow>
                      <hr />
                    </MDBCardBody>
                  </MDBCard>
                </MDBCol>
              </MDBRow>

              <CCol xs={12} className="d-flex justify-content-end">
                <CButton
                  className="text-right"
                  size="lg"
                  style={{ backgroundColor: '#232324de', color: '#e99313', borderColor: '#e99313' }}
                  type="submit"
                >
                  Update
                </CButton>
              </CCol>
            </CCardBody>
          </CForm>
        </CCard>
      </CCol>
    </CRow>
    
  )
}

export default TmretExecEdit
