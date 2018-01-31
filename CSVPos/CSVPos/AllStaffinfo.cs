using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVPos
{
    /// <summary>
    /// 날짜 : 2018-01-11 
    /// 작성자 : 위영범
    /// 내용 : 전체직원관리 클래스 
    /// </summary>
    class AllStaffinfo
    {
        private string empNum;
        public string 사번
        {
            get { return empNum; }
            set { empNum = value; }
        }

        private string SM_name;
        public string 이름
        {
            get { return SM_name; }
            set { SM_name = value; }
        }

        private int SM_age;
        public int 나이
        {
            get { return SM_age; }
            set { SM_age = value; }
        }

        private bool SM_gender;
        public bool 성별
        {
            get { return SM_gender; }
            set { SM_gender = value; }
        }

        private string SM_residentNum;
        public string 주민등록번호
        {
            get { return SM_residentNum; }
            set { SM_residentNum = value; }
        }

        private string SM_phoneNum;
        public string 휴대폰번호
        {
            get { return SM_phoneNum; }
            set { SM_phoneNum = value; }
        }

        private string SM_address;
        public string 주소
        {
            get { return SM_address; }
            set { SM_address = value; }
        }

        private DateTime SM_hiredate;
        public DateTime 입사일
        {
            get { return SM_hiredate; }
            set { SM_hiredate = value; }
        }

        private DateTime myVar;
        public DateTime MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }

        private DateTime SM_firedate;
        public DateTime 퇴사일
        {
            get { return SM_firedate; }
            set { SM_firedate = value; }
        }

        private bool SM_employForm;
        public bool 고용형태
        {
            get { return SM_employForm; }
            set { SM_employForm = value; }
        }

        private string SM_employeer;
        public string 고용인 
        {
            get { return SM_employeer; }
            set { SM_employeer = value; }
        }

    }
}
