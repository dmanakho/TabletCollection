using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TabletCollection.Models
{
    public class studentDTO
    {
        public int household_fk { get; set; }
        public int person_pk { get; set; }
        public string legacy_id { get; set; }
        public string legacy_student_id { get; set; }
        public string name_prefix { get; set; }
        public string first_name { get; set; }
        public string first_nick_name { get; set; }
        public string preferred_name { get; set; }
        public string middle_name { get; set; }
        public string last_name { get; set; }
        public string name_suffix { get; set; }
        public string birthday { get; set; }
        public string gender { get; set; }
        public string ethnicity { get; set; }
        public string email_1 { get; set; }
        public bool display_email_1 { get; set; }
        public string email_2 { get; set; }
        public bool display_email_2 { get; set; }
        public string home_phone { get; set; }
        public bool display_home_phone { get; set; }
        public string mobile_phone { get; set; }
        public bool display_mobile_phone { get; set; }
        public int advisor_fk { get; set; }
        public string advisor_name { get; set; }
        public int homeroom_teacher_fk { get; set; }
        public object homeroom_teacher_name { get; set; }
        public int homeroom { get; set; }
        public Role[] roles { get; set; }
        public string current_grade { get; set; }
        public string grade_applying_for { get; set; }
        public int year_applying_for { get; set; }
        public bool resident_status_applying_for { get; set; }
        public bool student_group_applying_for { get; set; }
        public bool campus_applying_for { get; set; }
        public string school_level { get; set; }
        public string enrollment_status { get; set; }
        public bool new_student { get; set; }
        public int graduation_year { get; set; }
        public object resident_status { get; set; }
        public object campus { get; set; }
        public object dorm { get; set; }
        public object room_number { get; set; }
        public int floor_number { get; set; }
        public int bed_number { get; set; }
        public object mailbox_number { get; set; }
        public object student_group { get; set; }
        public int parent_1_fk { get; set; }
        public int parent_2_fk { get; set; }
        public int parent_3_fk { get; set; }
        public int parent_4_fk { get; set; }
        public string username { get; set; }
        public DateTime update_date { get; set; }
    }

    public class Role
    {
        public string description { get; set; }
    }

}