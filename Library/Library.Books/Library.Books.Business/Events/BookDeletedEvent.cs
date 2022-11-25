﻿using MediatR;
using Library.Hub.Rabbit.Events;

namespace Library.Books.Business.Events
{
    public class BookDeletedEvent : MessageEvent, IRequest<Unit>
    {
        public BookDeletedEvent()
        {

        }

        public BookDeletedEvent(string message, dynamic item = null)
        {
            Message = message;
            Item = item;
        }
    }
}
