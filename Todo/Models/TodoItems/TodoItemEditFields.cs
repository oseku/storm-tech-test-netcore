using Todo.Data.Entities;

namespace Todo.Models.TodoItems
{
    public class TodoItemEditFields: TodoItemCreateFields
    {       
        public int TodoItemId { get; set; }
        public bool IsDone { get; set; }
       

        public TodoItemEditFields() { }

        public TodoItemEditFields(int todoListId, string todoListTitle, int todoItemId, string title, bool isDone, string responsiblePartyId, Importance importance)
            :base(todoListId, todoListTitle, responsiblePartyId)
        {          
            TodoItemId = todoItemId;
            Title = title;
            IsDone = isDone;          
            Importance = importance;
        }
    }
}