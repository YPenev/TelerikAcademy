using System;

public class ExamResult
{
    private int grade;
    private int minGrade;
    private int maxGrade;
    private string comments;

    public int Grade
    {
        get
        {
            return this.grade;
        }
        private set
        {
            if (grade < 0)
            {
                throw new Exception("Invalid grade !");
            }
            else
            {
                this.grade = value;
            }
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }
        private set
        {
            if (minGrade < 0)
            {
                throw new Exception("Invalid minimal grade !");
            }
            else
            {
                this.minGrade = value;
            }
        }
    }
    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }
        private set
        {
            if (maxGrade <= minGrade)
            {
                throw new Exception("Invalid maximal grade !");
            }
            else
            {
                this.maxGrade = value;
            }
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }
        private set
        {
            if (comments == null || comments == "")
            {
                throw new Exception("Invalid comments !");
            }
            else
            {
                this.comments = value;
            }
        }
    }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
