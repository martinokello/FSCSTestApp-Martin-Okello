USE [FAQEntityDB]
GO
/****** Object:  StoredProcedure [dbo].[GetResultsStudentGradesPerQuestion]    Script Date: 10/18/2014 13:20:16 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[GetResultsStudentGradesPerQuestion] 
	-- Add the parameters for the stored procedure here
	@studentId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select * from Students s 
	where s.studentId = @studentId;
	
	select s.*,q.QuestionId,q.questionText,a.answerText,g.grade
	from questions q inner join Answers a on q.questionId = a.questionid
	inner join grades g on g.questionId = q.questionId 
	inner join students s on s.studentId = g.studentId
	where s.studentId = @studentId;
END
