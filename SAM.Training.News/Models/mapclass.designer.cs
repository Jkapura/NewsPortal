﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.17929
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAM.Training.News.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="EpoNews")]
	public partial class mapclassDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertArticle(Article instance);
    partial void UpdateArticle(Article instance);
    partial void DeleteArticle(Article instance);
    partial void InsertAuthor(Author instance);
    partial void UpdateAuthor(Author instance);
    partial void DeleteAuthor(Author instance);
    partial void InsertCategory(Category instance);
    partial void UpdateCategory(Category instance);
    partial void DeleteCategory(Category instance);
    #endregion
		
		public mapclassDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["EpoNewsConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public mapclassDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public mapclassDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public mapclassDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public mapclassDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Article> Articles
		{
			get
			{
				return this.GetTable<Article>();
			}
		}
		
		public System.Data.Linq.Table<Author> Authors
		{
			get
			{
				return this.GetTable<Author>();
			}
		}
		
		public System.Data.Linq.Table<Category> Categories
		{
			get
			{
				return this.GetTable<Category>();
			}
		}
		
		public System.Data.Linq.Table<HotNew> HotNews
		{
			get
			{
				return this.GetTable<HotNew>();
			}
		}
		
		public System.Data.Linq.Table<ArchiveView> ArchiveViews
		{
			get
			{
				return this.GetTable<ArchiveView>();
			}
		}
		
		public System.Data.Linq.Table<Statistics> Statistics
		{
			get
			{
				return this.GetTable<Statistics>();
			}
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetTotalStatistic")]
		public ISingleResult<Statistics> GetTotalStatistic()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<Statistics>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.CountArchiveNews", IsComposable=true)]
		public System.Nullable<int> CountArchiveNews()
		{
			return ((System.Nullable<int>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.CountHotNews", IsComposable=true)]
		public System.Nullable<int> CountHotNews()
		{
			return ((System.Nullable<int>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.CountTotal", IsComposable=true)]
		public System.Nullable<int> CountTotal()
		{
			return ((System.Nullable<int>)(this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod()))).ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetByCategory")]
		public ISingleResult<Article> GetByCategory([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="Int")] System.Nullable<int> categoryId)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), categoryId);
			return ((ISingleResult<Article>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetHotNews")]
		public ISingleResult<Article> GetHotNews()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<Article>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetWeekStatistic")]
		public ISingleResult<Statistics> GetWeekStatistic()
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
			return ((ISingleResult<Statistics>)(result.ReturnValue));
		}
		
		[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.GetFromToDateNews")]
		public ISingleResult<Article> GetFromToDateNews([global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> from, [global::System.Data.Linq.Mapping.ParameterAttribute(DbType="DateTime")] System.Nullable<System.DateTime> to)
		{
			IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), from, to);
			return ((ISingleResult<Article>)(result.ReturnValue));
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Article")]
	public partial class Article : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private System.Nullable<int> _authorId;
		
		private System.Nullable<System.DateTime> _date;
		
		private string _head;
		
		private string _content;
		
		private int _categoryId;
		
		private bool _isArchive;
		
		private bool _hotNews;
		
		private EntityRef<Author> _Author;
		
		private EntityRef<Category> _Category;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnauthorIdChanging(System.Nullable<int> value);
    partial void OnauthorIdChanged();
    partial void OndateChanging(System.Nullable<System.DateTime> value);
    partial void OndateChanged();
    partial void OnheadChanging(string value);
    partial void OnheadChanged();
    partial void OncontentChanging(string value);
    partial void OncontentChanged();
    partial void OncategoryIdChanging(int value);
    partial void OncategoryIdChanged();
    partial void OnisArchiveChanging(bool value);
    partial void OnisArchiveChanged();
    partial void OnhotNewsChanging(bool value);
    partial void OnhotNewsChanged();
    #endregion
		
		public Article()
		{
			this._Author = default(EntityRef<Author>);
			this._Category = default(EntityRef<Category>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_authorId", DbType="Int")]
		public System.Nullable<int> authorId
		{
			get
			{
				return this._authorId;
			}
			set
			{
				if ((this._authorId != value))
				{
					if (this._Author.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnauthorIdChanging(value);
					this.SendPropertyChanging();
					this._authorId = value;
					this.SendPropertyChanged("authorId");
					this.OnauthorIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> date
		{
			get
			{
				return this._date;
			}
			set
			{
				if ((this._date != value))
				{
					this.OndateChanging(value);
					this.SendPropertyChanging();
					this._date = value;
					this.SendPropertyChanged("date");
					this.OndateChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_head", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string head
		{
			get
			{
				return this._head;
			}
			set
			{
				if ((this._head != value))
				{
					this.OnheadChanging(value);
					this.SendPropertyChanging();
					this._head = value;
					this.SendPropertyChanged("head");
					this.OnheadChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_content", DbType="NVarChar(MAX)")]
		public string content
		{
			get
			{
				return this._content;
			}
			set
			{
				if ((this._content != value))
				{
					this.OncontentChanging(value);
					this.SendPropertyChanging();
					this._content = value;
					this.SendPropertyChanged("content");
					this.OncontentChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_categoryId", DbType="Int NOT NULL")]
		public int categoryId
		{
			get
			{
				return this._categoryId;
			}
			set
			{
				if ((this._categoryId != value))
				{
					if (this._Category.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OncategoryIdChanging(value);
					this.SendPropertyChanging();
					this._categoryId = value;
					this.SendPropertyChanged("categoryId");
					this.OncategoryIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_isArchive", DbType="Bit NOT NULL")]
		public bool isArchive
		{
			get
			{
				return this._isArchive;
			}
			set
			{
				if ((this._isArchive != value))
				{
					this.OnisArchiveChanging(value);
					this.SendPropertyChanging();
					this._isArchive = value;
					this.SendPropertyChanged("isArchive");
					this.OnisArchiveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_hotNews", DbType="Bit NOT NULL")]
		public bool hotNews
		{
			get
			{
				return this._hotNews;
			}
			set
			{
				if ((this._hotNews != value))
				{
					this.OnhotNewsChanging(value);
					this.SendPropertyChanging();
					this._hotNews = value;
					this.SendPropertyChanged("hotNews");
					this.OnhotNewsChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Author_Article", Storage="_Author", ThisKey="authorId", OtherKey="id", IsForeignKey=true)]
		public Author Author
		{
			get
			{
				return this._Author.Entity;
			}
			set
			{
				Author previousValue = this._Author.Entity;
				if (((previousValue != value) 
							|| (this._Author.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Author.Entity = null;
						previousValue.Articles.Remove(this);
					}
					this._Author.Entity = value;
					if ((value != null))
					{
						value.Articles.Add(this);
						this._authorId = value.id;
					}
					else
					{
						this._authorId = default(Nullable<int>);
					}
					this.SendPropertyChanged("Author");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_Article", Storage="_Category", ThisKey="categoryId", OtherKey="id", IsForeignKey=true)]
		public Category Category
		{
			get
			{
				return this._Category.Entity;
			}
			set
			{
				Category previousValue = this._Category.Entity;
				if (((previousValue != value) 
							|| (this._Category.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Category.Entity = null;
						previousValue.Articles.Remove(this);
					}
					this._Category.Entity = value;
					if ((value != null))
					{
						value.Articles.Add(this);
						this._categoryId = value.id;
					}
					else
					{
						this._categoryId = default(int);
					}
					this.SendPropertyChanged("Category");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Author")]
	public partial class Author : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private EntitySet<Article> _Articles;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public Author()
		{
			this._Articles = new EntitySet<Article>(new Action<Article>(this.attach_Articles), new Action<Article>(this.detach_Articles));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Author_Article", Storage="_Articles", ThisKey="id", OtherKey="authorId")]
		public EntitySet<Article> Articles
		{
			get
			{
				return this._Articles;
			}
			set
			{
				this._Articles.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Articles(Article entity)
		{
			this.SendPropertyChanging();
			entity.Author = this;
		}
		
		private void detach_Articles(Article entity)
		{
			this.SendPropertyChanging();
			entity.Author = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Category")]
	public partial class Category : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _id;
		
		private string _name;
		
		private EntitySet<Article> _Articles;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnidChanging(int value);
    partial void OnidChanged();
    partial void OnnameChanging(string value);
    partial void OnnameChanged();
    #endregion
		
		public Category()
		{
			this._Articles = new EntitySet<Article>(new Action<Article>(this.attach_Articles), new Action<Article>(this.detach_Articles));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this.OnidChanging(value);
					this.SendPropertyChanging();
					this._id = value;
					this.SendPropertyChanged("id");
					this.OnidChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this.OnnameChanging(value);
					this.SendPropertyChanging();
					this._name = value;
					this.SendPropertyChanged("name");
					this.OnnameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Category_Article", Storage="_Articles", ThisKey="id", OtherKey="categoryId")]
		public EntitySet<Article> Articles
		{
			get
			{
				return this._Articles;
			}
			set
			{
				this._Articles.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Articles(Article entity)
		{
			this.SendPropertyChanging();
			entity.Category = this;
		}
		
		private void detach_Articles(Article entity)
		{
			this.SendPropertyChanging();
			entity.Category = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.HotNews")]
	public partial class HotNew
	{
		
		private int _id;
		
		private System.Nullable<System.DateTime> _date;
		
		private string _name;
		
		private string _Expr1;
		
		private string _content;
		
		private string _head;
		
		public HotNew()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int NOT NULL")]
		public int id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this._id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> date
		{
			get
			{
				return this._date;
			}
			set
			{
				if ((this._date != value))
				{
					this._date = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_name", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				if ((this._name != value))
				{
					this._name = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Expr1", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string Expr1
		{
			get
			{
				return this._Expr1;
			}
			set
			{
				if ((this._Expr1 != value))
				{
					this._Expr1 = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_content", DbType="NVarChar(MAX)")]
		public string content
		{
			get
			{
				return this._content;
			}
			set
			{
				if ((this._content != value))
				{
					this._content = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_head", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string head
		{
			get
			{
				return this._head;
			}
			set
			{
				if ((this._head != value))
				{
					this._head = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.ArchiveView")]
	public partial class ArchiveView
	{
		
		private System.Nullable<int> _id;
		
		private System.Nullable<System.DateTime> _date;
		
		private string _head;
		
		private string _AuthorName;
		
		private string _CategoryName;
		
		public ArchiveView()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_id", DbType="Int")]
		public System.Nullable<int> id
		{
			get
			{
				return this._id;
			}
			set
			{
				if ((this._id != value))
				{
					this._id = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_date", DbType="DateTime")]
		public System.Nullable<System.DateTime> date
		{
			get
			{
				return this._date;
			}
			set
			{
				if ((this._date != value))
				{
					this._date = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_head", DbType="VarChar(50)")]
		public string head
		{
			get
			{
				return this._head;
			}
			set
			{
				if ((this._head != value))
				{
					this._head = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AuthorName", DbType="VarChar(50)")]
		public string AuthorName
		{
			get
			{
				return this._AuthorName;
			}
			set
			{
				if ((this._AuthorName != value))
				{
					this._AuthorName = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CategoryName", DbType="VarChar(50) NOT NULL", CanBeNull=false)]
		public string CategoryName
		{
			get
			{
				return this._CategoryName;
			}
			set
			{
				if ((this._CategoryName != value))
				{
					this._CategoryName = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="")]
	public partial class Statistics
	{
		
		private int _CountArchiveNews;
		
		private int _CountHotNews;
		
		private int _CountTotal;
		
		public Statistics()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountArchiveNews")]
		public int CountArchiveNews
		{
			get
			{
				return this._CountArchiveNews;
			}
			set
			{
				if ((this._CountArchiveNews != value))
				{
					this._CountArchiveNews = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountHotNews")]
		public int CountHotNews
		{
			get
			{
				return this._CountHotNews;
			}
			set
			{
				if ((this._CountHotNews != value))
				{
					this._CountHotNews = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CountTotal")]
		public int CountTotal
		{
			get
			{
				return this._CountTotal;
			}
			set
			{
				if ((this._CountTotal != value))
				{
					this._CountTotal = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
