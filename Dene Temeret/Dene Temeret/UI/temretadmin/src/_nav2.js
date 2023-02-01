import React from 'react'
import CIcon from '@coreui/icons-react'
import {cilPeople, cilNewspaper,cilCog, cilSpeedometer,cilRunning, cilMoney } from '@coreui/icons'
import { CNavItem, CNavTitle } from '@coreui/react'

const _nav2 = [
  {
    component: CNavItem,
    name: 'Dashboard',
    to: '/dashboard',
    icon: <CIcon icon={cilSpeedometer} customClassName="nav-icon" />,
    badge: {
      color: 'info',
      text: 'NEW',
    },
  },
  {
    component: CNavTitle,
    name: 'Mahber',
  },

  {
    
    component:CNavItem,
    name:'Association Executives',
    to:"/mahberexec",
    icon:<CIcon icon={cilPeople} customClassName="nav-icon" />
  },

  {
    component: CNavItem,
    name: 'News',
    to: '/news',
    icon: <CIcon icon={cilNewspaper} customClassName="nav-icon" />,
  },

  {
    
    component:CNavItem,
    name:'Fans',
    to:"/degafi",
    icon:<CIcon icon={cilRunning} customClassName="nav-icon" />
  },
  {
    
    component:CNavItem,
    name:'Fans Payment',
    to:"/mahber/fanpayment",
    icon:<CIcon icon={cilMoney} customClassName="nav-icon" />
  },
  {
    
    component:CNavItem,
    name:'Fans Setting',
    to:"/mahber/degafisetting",
    icon:<CIcon icon={cilCog} customClassName="nav-icon" />
  },


  
  
]

export default _nav2
