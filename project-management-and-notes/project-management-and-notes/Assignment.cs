using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace project_management_and_notes
{
    public class Assignment
    {
        private String todo { get; set; }
        private bool isDone { get; set; }

        public Assignment()
        {
            // default constructor
            this.todo = "";
            this.isDone = false;
        }

        public String GetTodo()
        {
            return this.todo;
        }

        public void SetTodo(String todo)
        {
            this.todo = todo;
        }

        public bool GetIsDone()
        {
            return this.isDone;
        }

        public void SetIsDone(bool status)
        {
            this.isDone = status;
        }

        public override string ToString()
        {
            return this.GetTodo();
        }
    }
}
