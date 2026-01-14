using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewPublisherSubscriberExample
{
    class NewsArticle
    {
        public string Content
        {
            get; set;
        }
        public string Title
        {
            get; set;
        }
        public NewsArticle(string Content, string Title)
        {
            this.Content = Content;
            this.Title = Title;
        }
    }
    class NewsPublisher
    {
        public event EventHandler<NewsArticle> NewNewsPublish;
        public void PublishNews(string Content, string Title)
        {
            var Article=new NewsArticle(Content, Title);
            OnNewNewsPublisher(Article);
        }
        protected virtual void OnNewNewsPublisher(NewsArticle e) {
            NewNewsPublish?.Invoke(this, e);
        }
        
        
    }
    class NewsSubscriber
    {
        public string Name { get; set; }
        public void Subscribe(NewsPublisher publisher)
        {
            publisher.NewNewsPublish += HandleNewNews;
        }
        public void UnSubscribe(NewsPublisher publisher)
        {
            publisher.NewNewsPublish -= HandleNewNews;
        }
        public void HandleNewNews(object sender, NewsArticle article)
        {
            Console.WriteLine($"Publisher Name:{Name}");
            Console.WriteLine($"Title:{article.Title}");
            Console.WriteLine($"Content:{article.Content}");
            Console.WriteLine("");
        }
        public NewsSubscriber(string Name) { 
            this.Name = Name;
        }
    }
    public class Program
    {
       
        static void Main(string[] args)
        {
           
            NewsSubscriber subscriber = new NewsSubscriber("Mohammed");
            NewsPublisher publisher = new NewsPublisher();
            subscriber.Subscribe(publisher);
            publisher.PublishNews("aaaa", "bbbb");
            subscriber.UnSubscribe(publisher);
            publisher.PublishNews("dddd", "fffff");
            
        }
    }
}
