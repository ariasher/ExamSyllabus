using ExamSyllabus.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ExamSyllabus.Model
{
    /// <summary>
    /// This class is a model for Exams Table.
    /// </summary>
    public class ExamModel: BaseModel
    {
        public string ExamName { get; set; }

        /// <summary>
        /// This method is used to bind exams to the control of type list such as ListBox and ComboBox.
        /// </summary>
        /// <param name="control">Takes a control to bind data to it.</param>
        public void Binder(ListControl control)
        {
            IDataService<ExamModel> examService = new DataService<ExamModel>();
            var examData = examService.GetRecords(DatabaseTable.Exam);

            // Convert datatable data to a list, sort it by name.
            List<ExamModel> modelData = (from DataRow row in examData.Rows
                                         select new ExamModel
                                         {
                                             Deleted = Convert.ToBoolean(row[TableColumns.COMMON_DELETED]),
                                             Id = Convert.ToInt32(row[TableColumns.COMMON_ID]),
                                             ExamName = row[TableColumns.EXAM_EXAM_NAME].ToString()
                                         })
                                         .ToList();

            modelData = modelData.OrderBy(x => x.ExamName).ToList();

            // Add first record as default record.
            modelData.Insert(0, new ExamModel
            {
                Id = -1,
                Deleted = false,
                ExamName = "--SELECT EXAMS--"
            });

            control.DataSource = modelData;
            control.DisplayMember = TableColumns.EXAM_EXAM_NAME;
            control.ValueMember = TableColumns.COMMON_ID;
        }
    }
}
