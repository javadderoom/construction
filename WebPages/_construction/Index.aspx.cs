﻿using DataAccess;
using DataAccess.Repository;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Drawing;
using System.IO;

namespace WebPages._construction
{
    public partial class Index1 : System.Web.UI.Page
    {
        private void SetProjects()
        {
            string txt = "";
            ProjectsRepository rep = new ProjectsRepository();
            List<Project> plist = rep.Top5tProjects();

            //foreach (Project pr in plist)
            //{
            //    txt += "<div class='project mix catHouses'>  <img src='" + pr.ImgFisrtPage + "' alt='Project1' class='projectImg img-responsive'/>  <div class='projectDetails row m0'> <div class='fleft projectIcons btn-group' role='group'>  <a href= '" + "/Projects/" + pr.ProjectID + "/" + pr.Title.Replace(' ', '-') + "' class='btn btn-default'><i class='fa fa-file-o'></i></a> </div><div class='fright nameType'> <div class='row m0 projectName'>" + pr.Title + "</div></div></div></div>";
            //}
            foreach (Project pr in plist)
            {
                txt += "<a href= '" + "/Projects/" + pr.ProjectID + "/" + pr.Title.Replace(' ', '-') + "' ><div style=\"background-image:url('" + pr.ImgFisrtPage + "');\" class='block image '><div class='layer'></div><div class='p-container'><p class='img-p'>" + pr.Title + "</p></div></div></a>";
            }
            proj.InnerHtml = txt;
        }

        private void LoadSliders()
        {
            SliderRepository repSlider = new SliderRepository();
            Slider slide1 = repSlider.FindSlider(1);
            Slider slide2 = repSlider.FindSlider(2);
            Slider slide3 = repSlider.FindSlider(3);

            bImg1.Src = slide1.BackgroundImg;
            bImg2.Src = slide2.BackgroundImg;
            bImg3.Src = slide3.BackgroundImg;

            divText1.InnerHtml = slide1.Text;
            divText2.InnerHtml = slide2.Text;
            divText3.InnerHtml = slide3.Text;

            if (slide1.thumbnail != null)
            {
                rightPic.InnerHtml = "<img src='" + slide1.thumbnail + "' alt='عکس'/>";
            }
            if (slide2.thumbnail != null)
            {
                rightPic2.InnerHtml = "<img src='" + slide2.thumbnail + "' alt='عکس'/>";
            }
            if (slide3.thumbnail != null)
            {
                rightPic3.InnerHtml = "<img src='" + slide3.thumbnail + "' alt='عکس'/>";
            }

            if (slide1.Link != null)
            {
                diva1.InnerHtml = "<a type='button' href='" + slide1.Link + "' class='btn btn-default'>بیشتر بدانید</a>";
            }
            if (slide2.Link != null)
            {
                diva2.InnerHtml = "<a type='button' href='" + slide2.Link + "' class='btn btn-default'>بیشتر بدانید</a>";
            }
            if (slide3.Link != null)
            {
                diva3.InnerHtml = "<a type='button' href='" + slide3.Link + "' class='btn btn-default'>بیشتر بدانید</a>";
            }
        }

        private void fillServises()
        {
            GroupsRepository gr = new GroupsRepository();
            List<Group> groups = new List<Group>();
            groups = gr.LoadListAllGroups();
            Random random = new Random();
            List<string> icons = new List<string>();
            foreach (Group gp in groups)
            {
                string name = "";
                if (icons.Count != 0)
                {
                    int index = random.Next(icons.Count);
                    name = icons[index];
                    icons.RemoveAt(index);
                }
                else
                {
                    icons = new List<string> {   "fa-building"
            };
                    int index = random.Next(icons.Count);
                    name = icons[index];
                    icons.RemoveAt(index);
                }

                ourServises.InnerHtml += "<div class='item '><div class='row m0 service'><div class='row m0 innerRow item'><div><i class='fa " + name + "'></i><div class='serviceName'>" + gp.Title + "</div><div class='item-overlay left'><ul><li class='liLeft'><input type='button' onclick=\"window.location='/Blogs/" + gp.GroupID + "';\" value='مقالات'  class='btnLeftService'></li><li class='liRight'><input type='button' onclick=\"$('#modal" + gp.GroupID + "').modal('show');\"  value='زیر گروه ها'  class='btnRightService'></li></ul></div></div></div></div></div>";
                List<Group> templist = new List<Group>();
                templist = gr.LoadListSubGroup(gp.GroupID);
                string buttons = "";
                if (templist.Count != 0)
                {
                    foreach (Group sgp in templist)
                    {
                        buttons += " <input type='button' class='btn btn-warning' onclick=\"window.location='/Blogs/" + gp.GroupID + "/" + sgp.GroupID + "';\" style='margin: 5px' value='" + sgp.Title + "'/>";
                    }
                    modalsdiv.InnerHtml += "<div class='modal fade' id='modal" + gp.GroupID + "' tabindex='-1' role='dialog' aria-labelledby='modalAskSubmitUpdate-label' aria-hidden='true'> <div class='modal-dialog'> <div class='modal-content'> <div class='modal-header'> <button type='button' class='close' data-dismiss='modal' aria-hidden='true'>×</button> <h4 class='modal-title'> <span class='glyphicon glyphicon-warning-sign'></span> زیر گروه های " + gp.Title + " </h4> </div><div class='modal-body' style='direction: rtl'> " + buttons + " </div><div class='modal-footer'> </div></div></div></div>";
                }
                else
                {
                    modalsdiv.InnerHtml += "<div class='modal fade' id='modal" + gp.GroupID + "' tabindex='-1' role='dialog' aria-labelledby='modalAskSubmitUpdate-label' aria-hidden='true'> <div class='modal-dialog'> <div class='modal-content'> <div class='modal-header'> <button type='button' class='close' data-dismiss='modal' aria-hidden='true'>×</button> <h4 class='modal-title'> <span class='glyphicon glyphicon-warning-sign'></span> زیر گروه های " + gp.Title + " </h4> </div><div class='modal-body' style='direction: rtl'> <span style='color: red;font-weight: bold;'>این گروه زیر گروهی ندارد !</span> </div><div class='modal-footer'> </div></div></div></div>";
                }
            }
        }

        private void fillArticles(List<Article> artList)
        {
            string text = "";
            foreach (Article article in artList)
            {
                if (article.Abstract.Count() > 130)
                {
                    if (article.Title.Count() > 30)
                    {
                        if ((130 - (article.Title.Count() - 30)) < 1)
                        {
                            text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "/Blog/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' ><img src='" + article.ImgFirstPage + "' alt='عکس' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "/Blog/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p></p>...<a href = '" + "/Blog/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' class='readMore'>ادامه</a></div></div></div></div></li>";
                        }
                        else
                        {
                            text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "/Blog/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' ><img src='" + article.ImgFirstPage + "' alt='عکس' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "/Blog/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p>" + article.Abstract.Substring(0, 130 - (article.Title.Count() - 30)) + "</p>...<a href = '" + "/Blog/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' class='readMore'>ادامه</a></div></div></div></div></li>";
                        }
                    }
                    else
                    {
                        text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "/Blog/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' ><img src='" + article.ImgFirstPage + "' alt='عکس' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "/Blog/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p>" + article.Abstract.Substring(0, 130) + "</p>...<a href = '" + "/Blog/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' class='readMore'>ادامه</a></div></div></div></div></li>";
                    }
                }
                else
                {
                    text += "<li><div class='col-sm-4 blog'><div class='row m0 blogInner'><div class='row m0 blogDateTime'><i class='fa fa-calendar'></i>" + article.PostDateTime + "</div><div class='row m0 featureImg'><a href = '" + "/Blog/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' ><img src='" + article.ImgFirstPage + "' alt='عکس' class='img-responsive'/></a></div><div class='row m0 postExcerpts'><div class='row m0 postExcerptInner'><a href = '" + "/Blog/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' class='postTitle row m0'><h4>" + article.Title + "</h4></a><p>" + article.Abstract + "</p>...<a href = '" + "/Blog/" + article.ArticleID + "/" + article.Title.Replace(' ', '-') + "' class='readMore'>ادامه</a></div></div></div></div></li>";
                }
            }
            blogsContainer.InnerHtml = text;
        }

        private void bestEmploees()
        {
            string text = "";
            EmployeesRepository er = new EmployeesRepository();
            EmployeeProjectRepository ep = new EmployeeProjectRepository();
            DataTable dt = er.getTopEmploees();
            if (dt.Rows.Count != 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string fullName = dt.Rows[i][0].ToString();
                    string score = dt.Rows[i][1].ToString();
                    int id = dt.Rows[i][2].ToString().ToInt();
                    string projectCount = ep.getEmployeeProjectCount(id).ToString();
                    string img = er.getEmployeeByID(id).empImage;

                    text += "<div class='item '><div class='theBest '><div class='imgDiv'><img class='empImg' src='";
                    text += img;
                    text += "'/></div ><div class='employeeName'><h3>";
                    text += "";
                    text += fullName;
                    string txt = ResolveUrl("images/testimonial/down-arrow.png");
                    text += "</h3></div><div class='arrow row m0'><img src='" + txt + "'/></div><div class='projectNum'><h4>";
                    text += " تعداد پروژه ها";
                    text += "</h4><h3>";
                    text += projectCount;
                    text += "</h3></div><div class='EmployeeScore'><h4>";
                    text += "امتیاز</h4><h3>";
                    text += score;
                    text += "</h3></div></div></div>";
                }
                best.InnerHtml = text;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            fillServises();

            if (!IsPostBack)
            {
                SetProjects();
                List<Article> articles = new List<Article>();
                ArticleRepository artRep = new ArticleRepository();
                articles = artRep.Top3tArticles();

                fillArticles(articles);

                LoadSliders();
                bestEmploees();
            }
        }

        protected void subGroups_ServerClick(object sender, EventArgs e)
        {
        }

        protected void articles_ServerClick(object sender, EventArgs e)
        {
        }
    }
}